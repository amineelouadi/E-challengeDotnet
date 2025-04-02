using Microsoft.EntityFrameworkCore;
using SqliTp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public virtual T GetById(int id) => _dbSet.Find(id);

        public virtual IEnumerable<T> GetAll() => _dbSet.ToList();

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            => _dbSet.Where(predicate).ToList();

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dbSet.FirstOrDefault(predicate);

        public virtual bool Any(Expression<Func<T, bool>> predicate)
            => _dbSet.Any(predicate);

        public virtual int Count(Expression<Func<T, bool>> predicate = null)
            => predicate != null ? _dbSet.Count(predicate) : _dbSet.Count();

        public virtual IEnumerable<T> GetPaged(int pageNumber, int pageSize,
                                            Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();
        }

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual void AddRange(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(T entity) => _dbSet.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

        public virtual void RemoveWhere(Expression<Func<T, bool>> predicate)
            => _dbSet.RemoveRange(_dbSet.Where(predicate));

        public virtual int SaveChanges() => _context.SaveChanges();
    }
}
