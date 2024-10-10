using MediatR;
using Microsoft.AspNetCore.Mvc;
using Proyecto2.Mediator;

namespace Proyecto2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JabilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JabilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.User.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserByIdQuery(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
