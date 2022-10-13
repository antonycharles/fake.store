using Accounts.Application.Exceptions;
using Accounts.Application.Modules.User.DTO;
using Accounts.Application.Modules.User.Mappers;
using Accounts.Core.Enums;
using Accounts.Core.Repositories;

namespace Accounts.Application.Modules.User
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository _userRepository;
        
        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserResponse> CreateAsync(UserRequest userRequest)
        {
            var userExist = await _userRepository.AnyAsync(w => w.Email == userRequest.Email);
             
            if(userExist)
                throw new NotFoundException("User already exists");

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequest.Password + salt);

            var user = userRequest.ToUser();
            user.PasswordHash = passwordHash;
            user.Salt = salt;
            user.Status = StatusEnum.Active;
            user.CreatedAt = DateTime.UtcNow;

            user = await _userRepository.AddAsync(user);

            return user.ToResponse();
        }

        public async Task<UserResponse> GetOrCreateByEmailAsync(UserRequest request)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            
            if(user != null)
                user.ToResponse();

            return await CreateAsync(request);
        }
    }
}