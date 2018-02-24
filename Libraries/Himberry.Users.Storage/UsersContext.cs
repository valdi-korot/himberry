using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Himberry.Users.Storage.Entities;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

namespace Himberry.Users.Storage
{
    public sealed class UsersContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<UserInfoEntity> UserInfo { get; set; }
        public DbSet<TraningEntity> Tranings { get; set; }

        public UsersContext() : base("usersDbConnectionString")
        { }

        public UsersContext(string authConnectionString) :
            base(authConnectionString)
        { }
    }
}