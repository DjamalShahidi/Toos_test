using Microsoft.EntityFrameworkCore;
using Test.Application.Contracts.Persistence;

namespace Test.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Domain.User>, IUserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<bool> IsExistWithCode(int code)
        {
            return await _context.Users.AnyAsync(a => a.Code == code);
        }
    }
}
