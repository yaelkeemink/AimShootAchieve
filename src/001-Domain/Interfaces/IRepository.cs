﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _001_Domain.Interfaces
{
    public interface IRepository<TEntity>
        : IDisposable
        where TEntity: class
    {
        IQueryable<TEntity> FindAll(string userId);
        IQueryable<TEntity> FindAllPublic(string userName);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter, string userId);

        TEntity Find(int id, string userId);
        TEntity FindPublic(int id);
        void Insert(TEntity item);
        void Update(TEntity item);

        void Delete(TEntity item);        
    }
}
