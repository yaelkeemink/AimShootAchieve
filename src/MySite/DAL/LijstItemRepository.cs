using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class LijstItemRepository
        : BaseRepository<LijstItem, int, DatabaseContext>
    {
        public LijstItemRepository(DatabaseContext context) 
            : base(context)
        {
        }
        public override LijstItem Find(int id)
        {
            return _context.LijstItems.Where(a => a.LijstjeId == id)
                .Include(a => a.Lijstje)
                .FirstOrDefault();
        }

        public override IEnumerable<LijstItem> FindAll()
        {
            return _context.LijstItems
                .Include(a => a.Lijstje);
        }

        protected override DbSet<LijstItem> GetDbSet()
        {
            return _context.LijstItems;
        }

        protected override int GetKeyFrom(LijstItem item)
        {
            return item.LijstjeId;
        }
    }
}

