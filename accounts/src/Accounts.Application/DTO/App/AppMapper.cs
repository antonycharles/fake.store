using Accounts.Application.DTO.Apps;
using Accounts.Core.Entities;

namespace Accounts.Core.DTO.Apps
{
    public static class AppMapper
    {
        public static App ToModel(this AppRequest request)
        {
            return new App(){
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static void ToModel(this App app, AppRequest appRequest)
        {
            app.Name = appRequest.Name;
            app.Description = appRequest.Description;
            app.Status = appRequest.Status;
            app.UpdatedAt = DateTime.UtcNow;
        }

        public static AppResponse ToResponse(this App app)
        {
            return new AppResponse(){
                Id = app.Id,
                Name = app.Name,
                Description = app.Description,
                Status = app.Status,
                CreatedAt = app.CreatedAt,
                UpdatedAt = app.UpdatedAt
            };
        }
    }
}