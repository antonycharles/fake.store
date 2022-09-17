using System.ComponentModel.DataAnnotations;
using Accounts.Core.Enums;

namespace Accounts.Core.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid PublicKey { get; set; }
        [Required]
        public string SecretKey { get; set; }
        public bool IsAppAuthentication { get; set; }
        public StatusEnum Status { get; set; }
        [Required]
        public Guid AppId { get; set; }
        public virtual App App { get; set; }
        public ICollection<ClientProfile> ClientsProfiles { get; set; }
    }
}