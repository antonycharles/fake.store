using Accounts.Application.Modules.Authorization.DTO;
using Accounts.Application.Modules.User;
using Accounts.Application.Modules.User.DTO;
using Accounts.Application.Modules.UserProfile;
using Accounts.Application.Modules.UserProfile.DTO;
using Accounts.Core.Repositories;

namespace Accounts.Application.Modules.Authorization
{
    public class AuthorizationHandler : IAuthorizationHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserHandler _userHandler;
        private readonly IUserProfileHandler _userProfileHandler;

        public AuthorizationHandler(
            IUserRepository userRepository,
            IUserHandler userHandler,
            IUserProfileHandler userProfileHandler)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userHandler = userHandler ?? throw new ArgumentNullException(nameof(userHandler));
            _userProfileHandler = userProfileHandler ?? throw new ArgumentNullException(nameof(userProfileHandler));
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var user = await _userHandler.GetOrCreateByEmailAsync(request);

            _ = await _userProfileHandler.CreateAsync(new UserProfileRequest{
                UserId = user.Id,
                PrifileId = request.ProfileId,
                AppId = request.AppId
            });
        }

        public async Task ValidateAsync(LoginRequest request)
        {
            var userDb = await _userRepository.GetByEmail(request.Email);

            if(userDb == null || userDb.PasswordHash != BCrypt.Net.BCrypt.HashPassword(request.Password + userDb.Salt))
                throw new Exception("User or password invalid");
        }
    }
}