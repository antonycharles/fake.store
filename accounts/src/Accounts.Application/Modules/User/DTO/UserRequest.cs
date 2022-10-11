using System.ComponentModel.DataAnnotations;
using Accounts.Application.Modules.Authorization.DTO;

namespace Accounts.Application.Modules.User.DTO;

public class UserRequest : LoginRequest
{
    [Required]
    [StringLength(100, MinimumLength = 3 )]  
    public string FirstName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3 )]
    public string LastName { get; set; }
}