using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqliTp.Data.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        // Ajoute une nouvelle entité
        void Add(T entity);

        // Ajoute une collection d'entités
        void AddRange(IEnumerable<T> entities);

        // Met à jour une entité
        void Update(T entity);

        // Supprime une entité
        void Remove(T entity);

        // Supprime une collection d'entités
        void RemoveRange(IEnumerable<T> entities);

        // Supprime selon un filtre
        void RemoveWhere(Expression<Func<T, bool>> predicate);

        // Enregistre les changements
        int SaveChanges();
    }
}
