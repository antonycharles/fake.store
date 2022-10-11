using Accounts.Application.Modules.UserProfile.DTO;

namespace Accounts.Application.Modules.UserProfile
{
    public interface IUserProfileHandler
    {
        Task CreateAsync(UserProfileRequest userProfileRequest);
    }
}