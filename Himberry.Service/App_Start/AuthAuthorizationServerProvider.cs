using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Himbarry.Users.Provider.Interfaces.Exceptions;
using Himberry.DepencyConfigurator;
using Himbarry.Users.Provider.Interfaces.Managers;

namespace Himberry.Service
{
    public sealed class AuthAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userFactory = AutofacConfigurator.Resolve<IUserFactory>();
            try
            {
                var user = await userFactory.GetUserAsync(context.UserName, context.Password);
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId, ClaimValueTypes.String));
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            catch (UserNotFoundException)
            {
                context.SetError("invalid credentials", "User not found");
                return;
            }
        }
    }
}