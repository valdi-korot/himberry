using System.Threading.Tasks;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himbarry.Users.Provider.Interfaces.Models;
using Himbarry.Users.Storage.Interfaces.Exceptions;
using Himbarry.Users.Storage.Interfaces.Managers;
using Himbarry.Users.Storage.Interfaces.Models;
using Himberry.Common.Helpers;

namespace Himbarry.Users.Provider.Models
{
    public sealed class User : IUser
    {
        private bool _isNew;
        private readonly string _password;
        private readonly IUserDataManager _userDataManager;
        private UserInfo _userInfo;

        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public IUserInfo UserInfo { get { return _userInfo; } }

        public User(string userName, string password, string mail, IUserDataManager userDataManager)
        {
            _isNew = true;
            UserName = userName;
            _password = password;
            Email = mail;
            _userDataManager = userDataManager;
            _userInfo = new UserInfo(UserId, _userDataManager);
        }

        public User(UserDataModel user, IUserDataManager userDataManager)
        {
            UserName = user.UserName;
            Email = user.Email;
            UserId = user.UserId;
            _userDataManager = userDataManager;
            var userInfoDataModel = _userDataManager.GetUserInfoAsync(UserId);
            userInfoDataModel.Wait();
            _userInfo = new UserInfo(userInfoDataModel.Result, _userDataManager);
        }

        public async Task SaveAsync()
        {
            try
            {
                if (_isNew)
                {
                    UserDataModel userDataModel = Converter.Convert<UserDataModel, User>(this);
                    await _userDataManager.RegisterUserAsync(userDataModel, _password);
                    userDataModel = await _userDataManager.GetUserAsync(UserName, _password);
                    UserId = userDataModel.UserId;
                    _isNew = false;
                }
                await _userInfo.SaveAsync();
            }
            catch (UserNotFoundDataException)
            {
                throw new UserNotFoundException();
            }
            catch (UserRegisterDataException)
            {
                throw new UserRegisterException();
            }
        }
    }
}
