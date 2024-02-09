using CQRS_Demo.Domain.Entities;
using MediatR;

namespace CQRS_Demo.Application.Members.Commands
{
    public sealed class DeleteMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }
    }
}
