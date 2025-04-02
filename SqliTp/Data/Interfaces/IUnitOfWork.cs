using SqliTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Data.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Teacher> Teachers { get; }

        int Complete();
    }
}
