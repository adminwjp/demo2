using EventCloud.Authorization.Roles;
using EventCloud.Events;
using EventCloud.MultiTenancy;
using EventCloud.Users;
#if NET5_0
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Abp.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
#else
using System.Data.Entity;
using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using System.Data.Common;
#endif
namespace EventCloud.EntityFramework
{
    public class EventCloudDbContext :
#if NET5_0
        AbpZeroDbContext<Tenant, Role, User, EventCloudDbContext>
#else
        AbpZeroDbContext<Tenant, Role, User>
#endif
    {
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
#if NET5_0
        public EventCloudDbContext(DbContextOptions<EventCloudDbContext> dbContextOptions)
                    : base(dbContextOptions)
        {

        }
#else
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EventCloudDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in EventCloudDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of EventCloudDbContext since ABP automatically handles it.
         */
        public EventCloudDbContext(string nameOrConnectionString)
            : base(new System.Data.SQLite.SQLiteConnection(
            System.Configuration.ConfigurationManager.ConnectionStrings[nameOrConnectionString]==null?
            nameOrConnectionString: System.Configuration.ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString
            ),false)
        {
            Database.SetInitializer<EventCloudDbContext>(null);
        }

        //This constructor is used in tests
        public EventCloudDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
#endif
    }
}
