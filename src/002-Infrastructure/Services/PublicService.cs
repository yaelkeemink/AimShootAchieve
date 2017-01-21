using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _002_Infrastructure.Services
{
    public class PublicService<Entity>
        : IPublicService<Entity>
        where Entity : BaseEntity
    {
        private IRepository<Entity> _repo;

        public PublicService(IRepository<Entity> repo)
        {
            _repo = repo;
        }

        public Entity FindPublicReis(int id)
        {
            return _repo.FindPublic(id);
        }

        public IEnumerable<Entity> FindPublicReizen(string userName)
        {
            return _repo.FindAllPublic(userName);
        }
    }
}
