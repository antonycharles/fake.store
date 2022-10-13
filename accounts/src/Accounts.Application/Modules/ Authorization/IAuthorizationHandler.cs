using Accounts.Application.Modules.Authorization.DTO;

namespace Accounts.Application.Modules.Authorization
{
    public interface IAuthorizationHandler
    {
        Task RegisterAsync(RegisterRequest request);
        Task ValidateAsync(LoginRequest request);
    }
}