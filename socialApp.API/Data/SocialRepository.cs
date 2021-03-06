using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using socialApp.API.Helpers;
using socialApp.API.Models;

namespace socialApp.API.Data
{
    public class SocialRepository : ISocialRepository
    {
        private readonly DataContext _context;
        public SocialRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u => u.LikerId == userId && u.LikeeId == recipientId);
        }

        public Task<Photo> GetMainPhotoForUser(int userId)
        {
            return _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id, bool isCurrentUser)
        {
            var query = _context.Users.Include(p => p.Photos).AsQueryable();

            if (isCurrentUser)
            {
                query = query.IgnoreQueryFilters();
            }

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

            if (userParams.IsGetLikers)
            {
                var userLikers = await GetUserLikes(userParams.UserId, userParams.IsGetLikers);
                users = users.Where(u => userLikers.Contains(u.Id));
            }

            if (userParams.IsGetLikees)
            {
                var userLikees = await GetUserLikes(userParams.UserId, userParams.IsGetLikers);
                users = users.Where(u => userLikees.Contains(u.Id));
            }

            if (!userParams.IsGetLikers && !userParams.IsGetLikees)
            {
                users = users.Where(u => u.Gender == userParams.Gender);
            }

            if (userParams.MinAge != 18 || userParams.MaxAge != 99) 
            {
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy)) 
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<IEnumerable<int>> GetUserLikes(int id, bool isGetLikers)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (isGetLikers) 
                {
                    return user.Likers.Where(u => u.LikeeId == id).Select(i => i.LikerId);
                }
                else {
                    return user.Likees.Where(u => u.LikerId == id).Select(i => i.LikeeId);
                }
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && !u.RecipientDeleted);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId && !u.SenderDeleted);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && !u.RecipientDeleted && !u.IsRead);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return PagedList<Message>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages
                .Where(m => m.RecipientId == userId && !m.RecipientDeleted && m.SenderId == recipientId
                    || m.RecipientId == recipientId && m.SenderId == userId && !m.SenderDeleted)
                .OrderByDescending(m => m.MessageSent)
                .ToListAsync();

            return messages;
        }
    }
}