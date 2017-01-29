using _001_Domain.Entities;
using _001_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _002_Infrastructure.DAL.Repositories
{
    public abstract class BaseRepository<Entity, Context>
    : IRepository<Entity>        
        where Context : DbContext
        where Entity : BaseEntity
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
        protected abstract DbSet<Entity> GetDbSet();
        protected abstract int GetKeyFrom(Entity item);

        public virtual IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> filter, string userId)
        {
            return GetDbSet().Include(a => a.User)
                .Where(a => a.UserId == userId)
                .Where(filter);
        }

        public virtual Entity Find(int id, string userId)
        {
            return GetDbSet().Include(a => a.User)
                .Where(a => a.UserId == userId).Single(a => GetKeyFrom(a).Equals(id));
        }

        public virtual IQueryable<Entity> FindAll(string userId)
        {
            return GetDbSet().Include(a => a.User)
                .Where(a => a.UserId == userId);
        }

        public virtual void Insert(Entity item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public virtual void Update(Entity item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
        public virtual void Delete(Entity item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }        

        public virtual IQueryable<Entity> FindAllPublic(string naam)
        {
            return GetDbSet()
                .Include(a => a.User)
                .Where(a => !a.Prive && a.User.UserName == naam);
        }

        public virtual Entity FindPublic(int id)
        {
            return GetDbSet()
                .Include(a => a.User)
                .Where(a => a.Id == id && !a.Prive)
                .SingleOrDefault();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
