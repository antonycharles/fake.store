
using Accounts.Application.Modules.User.DTO;

namespace Accounts.Application.Modules.User
{
    public interface IUserHandler
    {
        Task<UserResponse> CreateAsync(UserRequest authorizationRequest);
        Task<UserResponse> GetOrCreateByEmailAsync(UserRequest authorizationRequest);
    }
}