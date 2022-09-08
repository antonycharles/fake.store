using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Core.Enums;

namespace Accounts.Core.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public bool IsSystem { get; set; }
        public StatusEnum Status { get; set; }
        public virtual Role FatherId { get; set; }
        [Required]
        public Guid ApplicationId { get; set; }
        public virtual App Application { get; set; }
        public ICollection<ProfileRole> RolesProfiles { get; set; }
    }
}