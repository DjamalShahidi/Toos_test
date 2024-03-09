using Test.Domain;

namespace Test.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsExistWithCode(int code);

    }
}
