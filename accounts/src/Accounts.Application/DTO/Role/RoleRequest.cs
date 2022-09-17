using System.ComponentModel.DataAnnotations;
using Accounts.Core.Enums;

namespace Accounts.Core.DTO.Roles
{
    public class RoleRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 5 )]  
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public bool IsSystem { get; set; }
        public Guid? FatherId { get; set; }
        [Required]
        public Guid AppId { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
    }
}