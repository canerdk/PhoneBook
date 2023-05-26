using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Features.Commands.Request.Persons;
using PhoneBook.Application.Features.Queries.Request.Persons;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPersonQueryRequest();
            var result = await _mediator.Send(query);

            if(result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdPersonQueryRequest(id);
            var result = await _mediator.Send(query);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add([FromBody] CreatePersonCommandRequest command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdatePersonCommandRequest command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeletePersonCommandRequest(id);
            var result = await _mediator.Send(query);

            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
