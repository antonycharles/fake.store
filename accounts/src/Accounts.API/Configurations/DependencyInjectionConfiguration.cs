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
            services.AddSingleton<AppHandler>();
        }


        private static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAppRepository,ApplicationRepository>();
        }
    }
}