using _001_Domain.Entities;
using _002_AimShootAchieve.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.DAL.Repositories
{
    public class ReisRepository
        : BaseRepository<Reis, int, DatabaseContext>
    {
        public ReisRepository(DatabaseContext context) 
            : base(context)
        {
        }

        protected override DbSet<Reis> GetDbSet()
        {
            return _context.Reizen;
        }

        protected override int GetKeyFrom(Reis item)
        {
            return item.Id;
        }

        public override IQueryable<Reis> FindAll(string userId)
        {
            return _context.Reizen.Include(a => a.Landen)
                .Where(a => a.UserId == userId);
        }

        public override Reis Find(int id, string userId)
        {
            return _context.Reizen.Include(a => a.Landen)
                .Where(a => a.Id == id && a.UserId == userId)
                .FirstOrDefault();
        }
    }
}