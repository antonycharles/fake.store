using Accounts.Application.Modules.UserProfile.DTO;

namespace Accounts.Application.Modules.UserProfile
{
    public interface IUserProfileHandler
    {
        Task<UserProfileResponse> CreateAsync(UserProfileRequest userProfileRequest);
    }
}