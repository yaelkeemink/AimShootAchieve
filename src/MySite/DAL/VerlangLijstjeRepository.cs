using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class VerlangLijstjeRepository
        : BaseRepository<Verlanglijstje, int, DatabaseContext>
    {
        public VerlangLijstjeRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Verlanglijstje> GetDbSet()
        {
            return _context.Verlanglijstje;
        }

        protected override int GetKeyFrom(Verlanglijstje item)
        {
            return item.Id;
        }
    }
}