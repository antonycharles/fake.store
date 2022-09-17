using Accounts.Application.DTO.Roles;
using Accounts.Application.Exceptions;
using Accounts.Core.DTO.Roles;
using Accounts.Core.Entities;
using Accounts.Core.Repositories;

namespace Accounts.Application.Handlers
{
    public class RoleHandler
    {
        private readonly IRoleRepository _roleRepository;
        
        public RoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleResponse>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            return roles.Select(s => s.ToResponse());
        }

        public async Task<RoleResponse> GetByIdAsync(Guid id)
        {
            var role = await GetRoleById(id);

            return role.ToResponse();
        }

        public async Task<RoleResponse> CreateAsync(RoleRequest roleRequest)
        {
            var role = roleRequest.ToModel();

            var roleDb = await _roleRepository.AddAsync(role);

            return roleDb.ToResponse();
        }

        public async Task UpdateAsync(Guid id, RoleRequest roleRequest)
        {
            var role = await GetRoleById(id);

            role.ToModel(roleRequest);

            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await GetRoleById(id);
            await _roleRepository.DeleteAsync(role);
        }

        private async Task<Role> GetRoleById(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if(role == null)
                throw new NotFoundException("Role_not_found");

            return role;
        }
    }
}