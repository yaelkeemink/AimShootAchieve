using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class VerlangLijstjeRepository
        : BaseRepository<Verlanglijst, int, DatabaseContext>
    {
        public VerlangLijstjeRepository(DatabaseContext context) : base(context)
        {
        }

        protected override DbSet<Verlanglijst> GetDbSet()
        {
            return _context.Verlanglijstje;
        }

        protected override int GetKeyFrom(Verlanglijst item)
        {
            return item.Id;
        }
    }
}