using Accounts.Application.DTO.Roles;
using Accounts.Core.Entities;

namespace Accounts.Core.DTO.Roles
{
    public static class RoleMapper
    {
        public static Role ToModel(this RoleRequest request)
        {
            return new Role(){
                Name = request.Name,
                Slug = request.Slug,
                IsSystem = request.IsSystem,
                Status = request.Status,
                FatherId = request.FatherId,
                AppId = request.AppId,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static void ToModel(this Role role, RoleRequest roleRequest)
        {
            role.Name = roleRequest.Name;
            role.Slug = roleRequest.Slug;
            role.IsSystem = roleRequest.IsSystem;
            role.Status = roleRequest.Status;
            role.FatherId = roleRequest.FatherId;
            role.AppId = roleRequest.AppId;
            role.UpdatedAt = DateTime.UtcNow;
        }

        public static RoleResponse ToResponse(this Role role)
        {
            return new RoleResponse(){
                Id = role.Id,
                Name = role.Name,
                Slug = role.Slug,
                IsSystem = role.IsSystem,
                Status = role.Status,
                FatherId = role.FatherId,
                AppId = role.AppId,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt
            };
        }
    }
}