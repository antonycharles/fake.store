using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.Modules.UserProfile.DTO;
using Accounts.Core.Entities;

namespace Accounts.Application.Modules.UserProfile.Mappers
{
    public static class UserProfileResponseMapper
    {
        public static UserProfileResponse ToResponse(this UserProfileEntity entity) => new UserProfileResponse
        {
            PrifileId = entity.ProfileId,
            UserId = entity.UserId
        };
    }
}