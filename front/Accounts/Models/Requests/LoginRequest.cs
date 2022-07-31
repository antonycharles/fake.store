using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Requests
{
    public class LoginRequest
    {
        [DisplayName("Email")]
        [Required(AllowEmptyStrings=false)]
        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(AllowEmptyStrings=false)]
        public string Password { get; set; }
    }
}