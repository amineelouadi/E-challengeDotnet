using Microsoft.EntityFrameworkCore;
using SqliTp.Models;
using SqliTp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SqliTp.Data.Repositories
{
    internal class StudentRepository : IRepository<Student>
    {
        protected readonly MyContext _context;
        protected readonly DbSet<Student> _dbSet;

        public StudentRepository(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Student>();
        }

        public void Add(Student entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            _dbSet.AddRange(entities);
        }

        public bool Any(Expression<Func<Student, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public int Count(Expression<Func<Student, bool>> predicate = null)
        {
            return predicate != null ? _dbSet.Count(predicate) : _dbSet.Count();
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return _dbSet.Where(predicate).Include(s => s.Personal).ToList();
        }

        public Student FirstOrDefault(Expression<Func<Student, bool>> predicate)
        {
            return _dbSet.Include(s => s.Personal).FirstOrDefault(predicate);
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbSet.Include(s => s.Personal).ToList();
        }

        public Student GetById(int id)
        {
            return _dbSet.Include(s => s.Personal).FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetPaged(int pageNumber, int pageSize, Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null)
        {
            IQueryable<Student> query = _dbSet.Include(s => s.Personal);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public IEnumerable<Student> GetTopStudents(int count)
        {
            return _dbSet.OrderByDescending(s => s.Id) 
                       .Take(count)
                       .ToList();
        }

        public void Remove(Student entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void RemoveWhere(Expression<Func<Student, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate);
            _dbSet.RemoveRange(entities);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Student entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
