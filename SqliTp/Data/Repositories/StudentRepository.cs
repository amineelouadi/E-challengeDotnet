using Microsoft.EntityFrameworkCore;
using SqliTp.Models;
using SqliTp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Data.Repositories
{
    internal class StudentRepository : BaseRepository<Student>, IRepository<Student>
    {
        public StudentRepository(MyContext context) : base(context) { }

        public IEnumerable<Student> GetTopStudents(int count)
        {
            return _dbSet.OrderByDescending(s => s.Id) 
                       .Take(count)
                       .ToList();
        }
    }
}
