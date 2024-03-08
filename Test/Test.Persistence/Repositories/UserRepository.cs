using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
