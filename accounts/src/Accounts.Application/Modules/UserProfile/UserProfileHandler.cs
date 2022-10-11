using Accounts.Application.Exceptions;
using Accounts.Application.Modules.UserProfile.DTO;
using Accounts.Application.Modules.UserProfile.Mappers;
using Accounts.Core.Entities;
using Accounts.Core.Repositories;

namespace Accounts.Application.Modules.UserProfile
{
    public class UserProfileHandler : IUserProfileHandler
    {
        public readonly IUserProfileRepository _userProfileRepository;
        public readonly IProfileRepository _profileRepository;

        public UserProfileHandler(
            IUserProfileRepository userProfileRepository,
            IProfileRepository profileRepository)
        {
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
            _profileRepository = profileRepository ?? throw new ArgumentNullException(nameof(profileRepository));
        }

        public async Task CreateAsync(UserProfileRequest userProfileRequest)
        {
            var profiles = await _profileRepository.GetAsync(w => w.AppId == userProfileRequest.AppId);

            await ValidateUserProfile(userProfileRequest, profiles);

            var profile = GetProfile(userProfileRequest, profiles);

            userProfileRequest.PrifileId = profile.Id;

            var userProfile = await _userProfileRepository.AddAsync(userProfileRequest.ToUserProfile());

        }

        private async Task ValidateUserProfile(UserProfileRequest userProfileRequest, IEnumerable<ProfileEntity> profiles)
        {
            var userProfileExist = await _userProfileRepository.AnyAsync(w =>
                            w.ProfileId == userProfileRequest.PrifileId &&
                            w.UserId == userProfileRequest.UserId);

            if (userProfileExist)
                throw new ConflictException("User profile exist");

            var userProfileForAppExist = await _userProfileRepository.AnyAsync(w =>
                w.UserId == userProfileRequest.UserId &&
                profiles.Select(s => s.Id).Contains(w.ProfileId));

            if (userProfileForAppExist)
                throw new ConflictException("User profile for App exist");
        }

        private ProfileEntity GetProfile(UserProfileRequest userProfileRequest, IEnumerable<ProfileEntity> profiles)
        {
            var profile = profiles.FirstOrDefault(w =>
                w.AppId == userProfileRequest.AppId &&
                (
                    userProfileRequest.PrifileId == null &&
                    w.IsDefault
                ) ||
                (
                    userProfileRequest.PrifileId != null &&
                    w.Id == userProfileRequest.PrifileId
                ));

            if (profile == null)
                throw new NotFoundException("Profile not found");
                
            return profile;
        }
    }
}