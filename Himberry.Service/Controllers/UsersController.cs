using System;
using System.Net;
using System.Reflection;
using Himbarry.Users.Provider.Interfaces.Managers;
using Himberry.Service.Extentions;
using System.Threading.Tasks;
using System.Web.Http;
using Himbarry.Users.Provider.Interfaces.Enums;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himberry.Common.Helpers;
using Himberry.Service.Contrcts.IncomingContracts.Users;
using Himberry.Service.Contrcts.IncomingContracts.Users.Enums;
using log4net;
using Swashbuckle.Swagger.Annotations;

namespace Himberry.Service.Controllers
{
    [Authorize]
    [RoutePrefix("users")]
    public sealed class UsersController : ApiController
    {
        private readonly ILog _logger;
        private readonly IUserFactory _userFactory;

        public UsersController(IUserFactory userFactory)
        {
            _userFactory = userFactory;
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        [HttpPost]
        [Route("userInfo")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incoming contract is not valid")]
        [SwaggerResponse(HttpStatusCode.NotFound, "User not found")]
        public async Task<IHttpActionResult> SaveUserInfo(UserInfoIncomingContract userInfoIncomingContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = await _userFactory.GetUser(User.Identity.GetUserId<string>());
                user.UserInfo.FirstName = userInfoIncomingContract.FirstName;
                user.UserInfo.Weight = userInfoIncomingContract.Weight;
                user.UserInfo.Height = userInfoIncomingContract.Height;
                user.UserInfo.BirthDay = userInfoIncomingContract.BirthDay;
                user.UserInfo.Gender = Converter.Convert<Gender, GenderContract>(userInfoIncomingContract.Gender);
                user.UserInfo.Purpose = Converter.Convert<Purpose, PurposeContract>(userInfoIncomingContract.Purpose);
                user.UserInfo.TypeWork =
                    Converter.Convert<TypeWork, TypeWorkContract>(userInfoIncomingContract.TypeWork);
                user.UserInfo.ActiveTime = userInfoIncomingContract.DistributedTime.Active;
                user.UserInfo.PassiveTime = userInfoIncomingContract.DistributedTime.Passive;
                user.UserInfo.SleepTime = userInfoIncomingContract.DistributedTime.Sleep;
                user.UserInfo.WorkTime = userInfoIncomingContract.DistributedTime.Work;
                foreach (var traning in userInfoIncomingContract.Tranings)
                {
                    var intensity = Converter.Convert<Intensity, IntensityContract>(traning.Intensity);
                    user.UserInfo.AddTraining(traning.DayOfWeek, traning.AvgDuration, intensity);
                }

                await user.SaveAsync();
                return Ok();
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (FirstNameNotValidException)
            {
                return BadRequest("FirstName");
            }
            catch (ScheduleDayTimeNotValidException)
            {
                return BadRequest("ScheduleDayTime");
            }
            catch (Exception ex)
            {
                _logger.Error("SaveUserInfo ", ex);
                return InternalServerError();
            }
        }
    }
}
