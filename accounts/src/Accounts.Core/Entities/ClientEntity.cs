using System.ComponentModel.DataAnnotations;
using Accounts.Core.Enums;

namespace Accounts.Core.Entities
{
    public class ClientEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SecretKey { get; set; }
        public bool IsAppAuthentication { get; set; }
        public StatusEnum Status { get; set; }
        [Required]
        public Guid AppId { get; set; }
        public virtual AppEntity App { get; set; }
        public ICollection<ClientProfileEntity> ClientsProfiles { get; set; }
    }
}