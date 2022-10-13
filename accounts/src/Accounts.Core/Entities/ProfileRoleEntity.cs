using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts.Core.Entities
{
    public class ProfileRoleEntity
    {
        public Guid ProfileId { get; set; }
        public ProfileEntity Profile { get; set; }
        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}