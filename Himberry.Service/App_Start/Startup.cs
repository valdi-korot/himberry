using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using Himberry.DepencyConfigurator;
using log4net.Config;

[assembly: OwinStartup(typeof(Himberry.Service.Startup))]
[assembly: XmlConfigurator(Watch = true)]
namespace Himberry.Service
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            SwaggerConfig.Register(config);
            ConfigurationOAuth(app);
            WebApiConfig.Register(config);
            AutofacConfigurator.ConfigureContainer(config, Assembly.GetExecutingAssembly());
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            MappingInitializer.Init();
        }

        public void ConfigurationOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOption = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOption);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}