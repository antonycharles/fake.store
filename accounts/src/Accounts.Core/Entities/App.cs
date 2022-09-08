using System.ComponentModel.DataAnnotations;
using Accounts.Core.Enums;

namespace Accounts.Core.Entities
{
    public class App : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }
}