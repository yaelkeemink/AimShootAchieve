using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class ReisRepository
        : BaseRepository<Reis, int, DatabaseContext>
    {
        public ReisRepository(DatabaseContext context) : base(context)
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

        public override IEnumerable<Reis> FindAll()
        {
            return _context.Reizen.Include(a => a.Landen);
        }

        public override Reis Find(int id)
        {
            return _context.Reizen.Include(a => a.Landen)
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }
    }
}