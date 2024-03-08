using System.Linq.Expressions;

namespace Test.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T:class
    {
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter, int? from = null, int? to = null);

        Task<T> GetAsync(int id);
    }
}
