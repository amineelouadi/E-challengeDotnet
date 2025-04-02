using SqliTp.Data.Interfaces;
using SqliTp.Data.Repositories;
using SqliTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;
            Teachers = new GenericRepository<Teacher>(_context);
        }

        public IRepository<Student> Students { get; }
        public IRepository<Teacher> Teachers { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
