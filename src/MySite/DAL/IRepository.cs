using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public interface IRepository<TEntity, TKey>
        : IDisposable
    {
        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);

        TEntity Find(TKey id);

        int Insert(TEntity item);
        int Update(TEntity item);

        int InsertRange(IEnumerable<TEntity> items);
        void Delete(TEntity item);

        int Count();
    }
}
