using System.Collections.Generic;
using Himbarry.Users.Storage.Interfaces.Models;
using System.Threading.Tasks;

namespace Himbarry.Users.Storage.Interfaces.Managers
{
    public interface IUserDataManager
    {
        Task RegisterUserAsync(UserDataModel userDataModel, string password);
        Task<UserDataModel> GetUserAsync(string userName, string password);
        Task<UserDataModel> GetUserAsync(string userId);
        Task SaveUserInfoAsync(UserInfoDataModel userInfoDataModel, IReadOnlyCollection<TraningDataModel> obsoloteTranings);
        Task<UserInfoDataModel> GetUserInfoAsync(string userId);
    }
}
