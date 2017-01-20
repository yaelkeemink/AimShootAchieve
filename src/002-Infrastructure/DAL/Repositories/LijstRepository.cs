using _001_Domain.Entities;
using _002_AimShootAchieve.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.DAL.Repositories
{
    public class LijstRepository
        : BaseRepository<Lijst, int, DatabaseContext>
    {
        public LijstRepository(DatabaseContext context) 
            : base(context)
        {
        }
        public override Lijst Find(int id, string userId)
        {
            return _context.Lijsten.Where(a => a.Id == id && a.UserId == userId)
                .Include(a => a.Items)
                .FirstOrDefault();
        }

        public override IQueryable<Lijst> FindAll(string userId)
        {
            return _context.Lijsten
                .Include(a => a.Items)
                .Where(a => a.UserId == userId);
        }

        protected override DbSet<Lijst> GetDbSet()
        {
            return _context.Lijsten;
        }

        protected override int GetKeyFrom(Lijst item)
        {
            return item.Id;
        }
    }
}
