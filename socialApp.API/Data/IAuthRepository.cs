using System.Threading.Tasks;
using socialApp.API.Models;

namespace socialApp.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> login(string username, string password);

        Task<bool> userExists(string username);

    }
}