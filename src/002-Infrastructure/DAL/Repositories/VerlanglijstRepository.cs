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
        : BaseRepository<Verlanglijst, int, DatabaseContext>
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
    }
}