using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class LijstRepository
     : BaseRepository<Lijst, int, DatabaseContext>
    {
        public LijstRepository(DatabaseContext context) : base(context)
        {
        }
        public override Lijst Find(int id)
        {                
            return _context.Lijstjes.Where(a => a.LijstId == id)
                .Include(a => a.Items)
                .FirstOrDefault();
        }

        public override IEnumerable<Lijst> FindAll()
        {
            return _context.Lijstjes
                .Include(a => a.Items);
        }

        protected override DbSet<Lijst> GetDbSet()
        {
            return _context.Lijstjes;
        }

        protected override int GetKeyFrom(Lijst item)
        {
            return item.LijstId;
        }
    }
}
