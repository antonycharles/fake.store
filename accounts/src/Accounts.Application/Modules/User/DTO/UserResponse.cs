using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.DTO;
using Accounts.Core.Enums;

namespace Accounts.Application.Modules.User.DTO
{
    public class UserResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public StatusEnum Status { get; set; }
    }
}