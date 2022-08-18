using System.Linq.Expressions;
using UdemyWebApiProject.Repositories;

namespace UdemyWebApiProject.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken ct);
        Task<IEnumerable<T>> GetAll(CancellationToken ct);
        Task<T> Create(T entity, CancellationToken ct);
        Task<T> Update(T entity, CancellationToken ct);
    }
}
