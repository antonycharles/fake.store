using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Infrastructure.Data;
using Accounts.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Accounts.API.Configurations
{
    public static class DbConfiguration
    {

        public static void AddDataBase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
            builder.Services.AddDbContext<AccountsContext>(x => x.UseSqlServer(connectionString),ServiceLifetime.Singleton);
        }

        public static void AddMigration(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var db = services.GetRequiredService<AccountsContext>();
                    db.Database.Migrate();
                }
                catch (Exception exception)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(exception, "An error occurred migration the DB.");
                }
            }
        }

        public static void SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<AccountsContext>();
                
                AppSeeder.Seed(context);
                RoleSeeder.Seed(context);
                ClientSeeder.Seed(context);
                ProfileSeeder.Seed(context);
                ProfileRoleSeeder.Seed(context);
                ClientProfileSeeder.Seed(context);
            }
        }
    }
}