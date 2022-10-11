using Accounts.Application.Modules.Authorization;
using Accounts.Application.Modules.User;
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
            services.AddScoped<IAuthorizationHandler,AuthorizationHandler>();
            services.AddScoped<IUserHandler,UserHandler>();
           // services.AddScoped<AppHandler>();
           // services.AddScoped<RoleHandler>();
        }


        private static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppRepository,AppRepository>();
            services.AddScoped<IProfileRepository,ProfileRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        }
    }
}