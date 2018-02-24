using System.Threading.Tasks;

namespace Himbarry.Users.Provider.Interfaces.Models
{
    public interface IUser
    {
        string UserId { get; }
        string UserName { get; }
        string Email { get; }
        IUserInfo UserInfo { get; }
        Task SaveAsync();
    }
}
