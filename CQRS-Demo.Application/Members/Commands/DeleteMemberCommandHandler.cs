using CQRS_Demo.Domain.Abstractions;
using CQRS_Demo.Domain.Entities;
using MediatR;

namespace CQRS_Demo.Application.Members.Commands;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var memberToDelete = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

        if (memberToDelete is null)
            throw new InvalidOperationException("Member not found");

        await _unitOfWork.MemberRepository.DeleteMember(memberToDelete.Id);

        await _unitOfWork.CommitAsync();

        return memberToDelete;
    }
}
