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
        // Ajouter une nouvelle entité
        void Add(T entity);

        // Ajouter une collection d'entités
        void AddRange(IEnumerable<T> entities);

        // Met à jour une entité
        void Update(T entity);

        // Supprimer une entité
        void Remove(T entity);

        // Supprimer une collection d'entités
        void RemoveRange(IEnumerable<T> entities);

        // Supprimer selon un filtre
        void RemoveWhere(Expression<Func<T, bool>> predicate);

        // Enregistrer les changements
        int SaveChanges();
    }
}
