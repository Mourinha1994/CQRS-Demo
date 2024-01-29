namespace CQRS_Demo.Domain.Abstractions;

public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
}
