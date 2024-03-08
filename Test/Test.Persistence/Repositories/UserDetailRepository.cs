using Test.Application.Contracts.Persistence;

namespace Test.Persistence.Repositories
{
    public class UserDetailRepository : GenericRepository<Domain.UserDetail>, IUserDetailRepository
    {
        private readonly TestDbContext _context;

        public UserDetailRepository(TestDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
