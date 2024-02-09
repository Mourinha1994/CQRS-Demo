using CQRS_Demo.Domain.Entities;
using MediatR;

namespace CQRS_Demo.Application.Members.Commands;

public sealed class CreateMemberCommand : IRequest<Member>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
}
