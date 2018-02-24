using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himbarry.Users.Provider.Interfaces.Managers;
using Himberry.Service.Contrcts.IncomingContracts.Users;
using log4net;

namespace Himberry.Service.Controllers
{
    [RoutePrefix("account")]
    public sealed class AccountController : ApiController
    {
        private readonly ILog _logger;
        private readonly IUserFactory _userFactory;

        public AccountController(IUserFactory userDataManager)
        {
            _userFactory = userDataManager;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(UserIncomingContract userIncomingContract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var user = _userFactory.CreateUser(userIncomingContract.UserName,
                    userIncomingContract.Password,
                    userIncomingContract.Email);
                await user.SaveAsync();
                return Ok();
            }
            catch(UserRegisterException)
            {
                return BadRequest();
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                _logger.Error("Register method",ex);
                return InternalServerError();
            }
        }
    }
}