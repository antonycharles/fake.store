using Accounts.Application.DTO.Apps;
using Accounts.Application.Exceptions;
using Accounts.Core.DTO.Apps;
using Accounts.Core.Entities;
using Accounts.Core.Repositories;

namespace Accounts.Application.Handlers
{
    public class AppHandler
    {
        private readonly IAppRepository _appRepository;
        
        public AppHandler(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<IEnumerable<AppResponse>> GetAllAsync()
        {
            var apps = await _appRepository.GetAllAsync();

            return apps.Select(s => s.ToResponse());
        }

        public async Task<AppResponse> GetByIdAsync(Guid id)
        {
            var app = await GetAppById(id);

            return app.ToResponse();
        }

        public async Task<AppResponse> CreateAsync(AppRequest appRequest)
        {
            var app = appRequest.ToModel();

            var appDb = await _appRepository.AddAsync(app);

            return appDb.ToResponse();
        }

        public async Task UpdateAsync(Guid id, AppRequest appRequest)
        {
            var app = await GetAppById(id);

            app.ToModel(appRequest);

            await _appRepository.UpdateAsync(app);
        }

        public async Task DeleteAsync(Guid id)
        {
            var app = await GetAppById(id);
            await _appRepository.DeleteAsync(app);
        }

        private async Task<App> GetAppById(Guid id)
        {
            var app = await _appRepository.GetByIdAsync(id);

            if(app == null)
                throw new NotFoundException("App_not_found");

            return app;
        }
    }
}