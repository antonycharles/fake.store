using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.Modules.User.DTO;

namespace Accounts.Application.Modules. Authorization.DTO
{
    public class RegisterRequest : UserRequest
    {
        public Guid? ProfileId { get; set;}
    }
}