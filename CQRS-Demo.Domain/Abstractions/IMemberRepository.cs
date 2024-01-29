using CQRS_Demo.Domain.Entities;

namespace CQRS_Demo.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task DeleteMember(int id);
}
