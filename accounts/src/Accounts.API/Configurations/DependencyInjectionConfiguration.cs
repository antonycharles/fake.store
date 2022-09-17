using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.Handlers;
using Accounts.Core.Repositories;
using Accounts.Core.Repositories.Base;
using Accounts.Infrastructure.Repositories;
using Accounts.Infrastructure.Repositories.Base;

namespace Accounts.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddRepositoryDependencyInjection();

            services.AddHandlerDependencyInjection();
        }

        private static void AddHandlerDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<AppHandler>();
            services.AddScoped<RoleHandler>();
        }


        private static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppRepository,AppRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
        }
    }
}