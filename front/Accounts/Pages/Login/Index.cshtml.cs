using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Accounts.Models.Requests;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Accounts.Pages.Login;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }


    [BindProperty]
    public LoginRequest? LoginRequest { get; set; }
    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var licenseClaims = new List<Claim>(){
            new Claim(ClaimTypes.Name, "Andre"),
            new Claim(ClaimTypes.Email, "andre@gmail.com")
        };

        var claimsIdentity = new ClaimsIdentity(
            licenseClaims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true
            });

        return Redirect(string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl);
    }
}
