using _001_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _002_Infrastructure.DAL.Repositories
{
    public class ReisRepository
        : BaseRepository<Reis, DatabaseContext>
    {
        public ReisRepository(DatabaseContext context) 
            : base(context)
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

        public override IQueryable<Reis> FindAll(string userId)
        {
            return _context.Reizen.Include(a => a.Landen)
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.ReisStatus)
                .ThenBy(a => a.AankomstDatum)
                .ThenBy(a => a.Naam);
        }

        public override Reis Find(int id, string userId)
        {
            return _context.Reizen.Include(a => a.Landen)
                .Include(a => a.User)
                .Where(a => a.Id == id && a.UserId == userId)
                .FirstOrDefault();
        }
        public override Reis FindPublic(int id)
        {
            return GetDbSet()
                .Include(a => a.Landen)
                .Include(a => a.User)
                .Where(a => a.Id == id && !a.Prive)
                .SingleOrDefault();
        }
    }
}