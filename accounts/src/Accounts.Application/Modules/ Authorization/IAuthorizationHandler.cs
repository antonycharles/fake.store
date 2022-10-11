using Accounts.Application.Modules.Authorization.DTO;
using Accounts.Application.Modules.User.DTO;

namespace Accounts.Application.Modules.Authorization
{
    public interface IAuthorizationHandler
    {
        Task RegisterAsync(UserRequest request);
        Task ValidateAsync(LoginRequest request);
    }
}