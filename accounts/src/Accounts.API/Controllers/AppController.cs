using Accounts.Application.DTO.Apps;
using Accounts.Application.Exceptions;
using Accounts.Application.Handlers;
using Accounts.Core.DTO.Apps;
using Accounts.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private readonly AppHandler _appHandler;

        public AppController(AppHandler appHandler)
        {
            _appHandler = appHandler ?? throw new ArgumentNullException(nameof(appHandler));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<AppResponse>>> GetAsync()
        {
            try
            {
                var apps = await _appHandler.GetAllAsync();
                return Ok(apps);
            }
            catch (Exception e)
            {
             //   _logger.LogError(e, e.Message);
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AppResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AppResponse>> GetByIdAsync(Guid id)
        {
            try
            {
                var app = await _appHandler.GetByIdAsync(id);
                return Ok(app);
            }
            catch(NotFoundException e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, e.Message);
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        

        [HttpPost]
        [ProducesResponseType(typeof(AppResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AppResponse>> CreateAsync(AppRequest request)
        {
            try
            {
                return Created("", await _appHandler.CreateAsync(request));
            }
            catch(Exception e)
            {  
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AppRequest request)
        {
            try
            {
                await _appHandler.UpdateAsync(id, request);
                return Ok();
            }
            catch(NotFoundException e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _appHandler.DeleteAsync(id);

                return Ok();
            }
            catch(NotFoundException e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
    }
}