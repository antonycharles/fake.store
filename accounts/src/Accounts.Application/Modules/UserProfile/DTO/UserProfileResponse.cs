using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Application.Modules.UserProfile.DTO
{
    public class UserProfileResponse
    {
        public Guid UserId { get; set; }
        public Guid PrifileId { get; set; }
    }
}