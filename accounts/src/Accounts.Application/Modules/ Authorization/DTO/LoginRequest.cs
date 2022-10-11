using System.ComponentModel.DataAnnotations;

namespace Accounts.Application.Modules.Authorization.DTO
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public Guid ClientId { get; set;}
        public Guid? ProfileId { get; set;}
    }
}