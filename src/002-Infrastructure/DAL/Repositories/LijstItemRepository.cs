﻿using _001_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _002_Infrastructure.DAL.Repositories
{
    public class LijstItemRepository 
        : BaseRepository<LijstItem, DatabaseContext>
    {
        public LijstItemRepository(DatabaseContext context)
            : base(context)
        {
        }
        public override LijstItem Find(int id, string userId)
        {
            return _context.LijstItems.Where(a => a.Id == id && a.UserId == userId)
                .Include(a => a.Lijst)
                .Include(a => a.User)
                .FirstOrDefault();
        }

        public override IQueryable<LijstItem> FindAll(string UserId)
        {
            return _context.LijstItems
                .Include(a => a.Lijst)
                .Include(a => a.User)
                .Where(a => a.UserId == UserId);
        }

        protected override DbSet<LijstItem> GetDbSet()
        {
            return _context.LijstItems;
        }

        protected override int GetKeyFrom(LijstItem item)
        {
            return item.LijstId;
        }
    }
}
