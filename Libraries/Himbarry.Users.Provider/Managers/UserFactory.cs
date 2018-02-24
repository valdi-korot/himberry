using Himbarry.Users.Provider.Interfaces.Managers;
using Himbarry.Users.Provider.Interfaces.Models;
using Himbarry.Users.Provider.Models;
using Himbarry.Users.Storage.Interfaces.Managers;
using System.Threading.Tasks;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himbarry.Users.Storage.Interfaces.Exceptions;

namespace Himbarry.Users.Provider.Managers
{
    public sealed class UserFactory : IUserFactory
    {
        private IUserDataManager _userDataManager;

        public UserFactory(IUserDataManager userDataManager)
        {
            _userDataManager = userDataManager;
        }

        public IUser CreateUser(string userName, string password, string email)
        {
            var user = new User(userName, password, email, _userDataManager);
            return user;
        }

        public async Task<IUser> GetUser(string userId)
        {
            try
            {
                var userDataModel = await _userDataManager.GetUserAsync(userId);
                var user = new User(userDataModel, _userDataManager);
                return user;
            }
            catch (UserNotFoundDataException)
            {
                throw new UserNotFoundException();
            }
        }

        public async Task<IUser> GetUserAsync(string userName, string password)
        {
            try
            {
                var userDataModel = await _userDataManager.GetUserAsync(userName, password);
                var user = new User(userDataModel, _userDataManager);
                return user;
            }
            catch (UserNotFoundDataException)
            {
                throw new UserNotFoundException();
            }
        }
    }
}
