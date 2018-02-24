using System.Configuration;

namespace Himberry.Service.Configurations
{
    public static class HimberryDataBaseConfig
    {
        public static string UserDbConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["usersDbConnectionString"].ConnectionString;
            }
        }
    }
}
