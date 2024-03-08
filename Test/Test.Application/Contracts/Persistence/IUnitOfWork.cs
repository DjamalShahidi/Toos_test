using Microsoft.EntityFrameworkCore.Storage;

namespace Test.Application.Contracts.Persistence
{
    public interface IUnitOfWork :IDisposable
    {
        IUserRepository UserRepository { get; }

        IUserDetailRepository UserDetailRepository { get; }

        Task Save(CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
