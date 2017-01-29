using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _002_Infrastructure.Services.PublicServices
{
    public class BasePublicService<Entity>
        : IPublicService<Entity>
        where Entity : BaseEntity
    {
        protected readonly IRepository<Entity> _repo;

        public BasePublicService(IRepository<Entity> repo)
        {
            _repo = repo;
        }

        public virtual Entity FindPublic(int id)
        {
            return _repo.FindPublic(id);
        }

        public virtual IEnumerable<Entity> FindPublic(string userName)
        {
            return _repo.FindAllPublic(userName)
                .OrderBy(a => a.Naam);
        }
    }
}
