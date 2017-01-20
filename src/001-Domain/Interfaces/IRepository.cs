using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface IRepository<TEntity, TKey>
        where TEntity: class
    {
        IQueryable<TEntity> FindAll(string userId);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, string userId);

        TEntity Find(TKey id, string userId);

        void Insert(TEntity item);
        void Update(TEntity item);

        void Delete(TEntity item);
    }
}
