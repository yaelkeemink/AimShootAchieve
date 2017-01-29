using _001_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _002_Infrastructure.DAL.Repositories
{
    public class VerlanglijstItemRepository
        : BaseRepository<VerlanglijstItem, DatabaseContext>
    {
        public VerlanglijstItemRepository(DatabaseContext context) 
            : base(context)
        {
        }

        protected override DbSet<VerlanglijstItem> GetDbSet()
        {
            return _context.VerlanglijstItems;
        }

        protected override int GetKeyFrom(VerlanglijstItem item)
        {
            return item.Id;
        }
    }
}
