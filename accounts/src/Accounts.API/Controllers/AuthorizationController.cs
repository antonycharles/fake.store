using Accounts.Application.Modules.Authorization;
using Accounts.Application.Modules.Authorization.DTO;
using Accounts.Application.Modules.User.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationHandler _authorizationHandler;
    public AuthorizationController(IAuthorizationHandler authorizationHandler)
    {
        _authorizationHandler = authorizationHandler ?? throw new ArgumentNullException(nameof(authorizationHandler));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ValidateAsync(LoginRequest request)
    {
        try
        {
            await _authorizationHandler.ValidateAsync(request);
            return Ok();
        }
        catch(Exception e)
        {
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAsync(RegisterRequest request)
    {
        try
        {
            await _authorizationHandler.RegisterAsync(request);
            return Created("",new{});
        }
        catch(Exception e)
        {  
            return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
