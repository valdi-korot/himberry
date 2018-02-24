using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Himbarry.Users.Storage.Interfaces.Managers;
using Himberry.Service.Configurations;
using Himbarry.Users.Provider.Interfaces.Managers;
using Himbarry.Users.Provider.Managers;
using Himberry.Users.Storage.Managers;

namespace Himberry.DepencyConfigurator
{
    public sealed class AutofacConfigurator
    {
        private static IContainer _container;
        public static void ConfigureContainer(HttpConfiguration config, Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(assembly);
            builder.RegisterAssemblyModules(assembly);

            builder.RegisterType<UserDataManager>().As<IUserDataManager>()
                .WithParameter("userConnectionString", HimberryDataBaseConfig.UserDbConnectionString).SingleInstance();

            builder.RegisterType<UserFactory>().As<IUserFactory>();

            _container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }

        public static TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
    }
}
