using System.Collections.Generic;
using System.Threading.Tasks;
using socialApp.API.Models;

namespace socialApp.API.Data
{
    public interface ISocialRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);

         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
    }
}