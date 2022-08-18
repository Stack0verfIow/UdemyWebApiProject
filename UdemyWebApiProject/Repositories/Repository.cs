using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyWebApiProject.Data;
using UdemyWebApiProject.Interfaces;

namespace UdemyWebApiProject.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        protected DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T entity, CancellationToken ct)
        {
            var dbEntity = await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);

            return dbEntity.Entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken ct)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate, ct);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken ct)
        {
            var entities = await _dbSet.ToListAsync(ct);
            return entities;
        }

        public async Task<T> Update(T entity, CancellationToken ct)
        {
            var dbEntity = _dbSet.Update(entity);
            await _context.SaveChangesAsync(ct);
            return dbEntity.Entity;
        }
    }
}
