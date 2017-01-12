using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class LijstRepository
     : BaseRepository<Lijstje, int, DatabaseContext>
    {
        public LijstRepository(DatabaseContext context) : base(context)
        {
        }
        public override Lijstje Find(int id)
        {                
            return _context.Lijstjes.Where(a => a.LijstjeId == id)
                .Include(a => a.Items)
                .FirstOrDefault();
        }

        public override IEnumerable<Lijstje> FindAll()
        {
            return _context.Lijstjes
                .Include(a => a.Items);
        }

        protected override DbSet<Lijstje> GetDbSet()
        {
            return _context.Lijstjes;
        }

        protected override int GetKeyFrom(Lijstje item)
        {
            return item.LijstjeId;
        }
    }
}
