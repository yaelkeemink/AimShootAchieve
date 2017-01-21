using _001_Domain.Entities;
using _002_AimShootAchieve.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.DAL.Repositories
{
    public class VerlanglijstRepository
        : BaseRepository<Verlanglijst, DatabaseContext>
    {
        public VerlanglijstRepository(DatabaseContext context) 
            : base(context)
        {
        }

        protected override DbSet<Verlanglijst> GetDbSet()
        {
            return _context.Verlanglijsten;
        }

        protected override int GetKeyFrom(Verlanglijst item)
        {
            return item.Id;
        }

        public override Verlanglijst FindPublic(int id)
        {
            return GetDbSet()
                .Include(a => a.User)
                .Include(a => a.VerlanglijstItems)
                .Where(a => a.Id == id && !a.Prive)
                .SingleOrDefault();
        }
        public override Verlanglijst Find(int id, string userId)
        {
            return GetDbSet()
                .Include(a => a.VerlanglijstItems)
                .Include(a => a.User)
                .Where(a => a.UserId == userId).Single(a => GetKeyFrom(a).Equals(id));
        }
    }
}