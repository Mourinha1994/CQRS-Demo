﻿using CQRS_Demo.Domain.Abstractions;
using CQRS_Demo.Domain.Entities;
using MediatR;

namespace CQRS_Demo.Application.Members.Commands;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var existingMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

        if (existingMember is null)
        {
            throw new InvalidOperationException("Member not found");
        }

        existingMember.Update(request.FirstName, 
            request.LastName, 
            request.Gender, 
            request.Email, 
            request.IsActive);

        await _unitOfWork.CommitAsync();
        return existingMember;
    }
}
