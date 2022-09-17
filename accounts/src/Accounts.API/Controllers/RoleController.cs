using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounts.Application.DTO.Roles;
using Accounts.Application.Exceptions;
using Accounts.Application.Handlers;
using Accounts.Core.DTO.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleHandler _roleHandler;

        public RoleController(RoleHandler roleHandler)
        {
            _roleHandler = roleHandler ?? throw new ArgumentNullException(nameof(roleHandler));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RoleResponse>>> GetAsync()
        {
            try
            {
                var apps = await _roleHandler.GetAllAsync();
                return Ok(apps);
            }
            catch (Exception e)
            {
             //   _logger.LogError(e, e.Message);
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleResponse>> GetByIdAsync(Guid id)
        {
            try
            {
                var app = await _roleHandler.GetByIdAsync(id);
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
        [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoleResponse>> CreateAsync(RoleRequest request)
        {
            try
            {
                return Created("", await _roleHandler.CreateAsync(request));
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
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] RoleRequest request)
        {
            try
            {
                await _roleHandler.UpdateAsync(id, request);
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
                await _roleHandler.DeleteAsync(id);

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