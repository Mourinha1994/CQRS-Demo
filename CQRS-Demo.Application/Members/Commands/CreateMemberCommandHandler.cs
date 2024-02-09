using CQRS_Demo.Domain.Abstractions;
using CQRS_Demo.Domain.Entities;
using MediatR;

namespace CQRS_Demo.Application.Members.Commands;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new Member
            (
                request.FirstName,
                request.LastName,
                request.Gender,
                request.Email,
                request.IsActive
            );

        await _unitOfWork.MemberRepository.AddMember(member);
        await _unitOfWork.CommitAsync();

        return member;

    }
}
