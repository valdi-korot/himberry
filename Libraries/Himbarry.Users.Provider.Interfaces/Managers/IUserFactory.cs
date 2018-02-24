using Himbarry.Users.Provider.Interfaces.Models;
using System.Threading.Tasks;

namespace Himbarry.Users.Provider.Interfaces.Managers
{
    public interface IUserFactory
    {
        IUser CreateUser(string userName, string password, string email);
        Task<IUser> GetUserAsync(string userName, string password);
        Task<IUser> GetUser(string userId);
    }
}
