using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Application.Modules.UserProfile.DTO
{
    public class UserProfileRequest
    {
        public Guid UserId { get; set; }
        public Guid? PrifileId { get; set; }
        public Guid AppId { get; set; }
    }
}