using CQRS_Demo.Application.Members.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Demo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IActionResult> GetMember()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            var createdMember = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var updatedMember = await _mediator.Send(command);

            return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var command = new DeleteMemberCommand { Id = id };

            var deletedMember = await _mediator.Send(command);

            return deletedMember != null ? Ok(deletedMember) : NotFound("Member not found");
        }
    }
}
