using Accounts.Application.Modules.UserProfile.DTO;
using Accounts.Core.Entities;

namespace Accounts.Application.Modules.UserProfile.Mappers
{
    public static class UserProfileRequestMapper
    {
        public static UserProfileEntity ToUserProfile(this UserProfileRequest request) => new UserProfileEntity
        {
            ProfileId = request.PrifileId != null ? request.PrifileId.Value : Guid.Empty,
            UserId = request.UserId
        };
    }
}