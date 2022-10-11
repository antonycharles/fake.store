using Accounts.Application.Modules.Authorization.DTO;
using Accounts.Application.Modules.User;
using Accounts.Application.Modules.User.DTO;
using Accounts.Core.Repositories;

namespace Accounts.Application.Modules.Authorization
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserHandler _userHandler;
        
        public AuthorizationHandler(
            IUserRepository userRepository,
            IUserHandler userHandler)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));
        }

        public async Task RegisterAsync(UserRequest request)
        {
            var user = await _userHandler.CreateAsync(request);
        }

        public async Task ValidateAsync(LoginRequest request)
        {
            var userDb = await _userRepository.GetByEmail(request.Email);

            if(userDb == null || userDb.PasswordHash != BCrypt.Net.BCrypt.HashPassword(request.Password + userDb.Salt))
                throw new Exception("");
        }
    }
}