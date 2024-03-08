using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contracts.Persistence;

namespace Test.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext _context;

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public IUserDetailRepository UserDetailRepository => _userDetailRepository ??= new UserDetailRepository(_context);

        private IUserRepository _userRepository;
        private IUserDetailRepository _userDetailRepository;



        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
