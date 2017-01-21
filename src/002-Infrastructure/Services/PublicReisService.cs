using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _002_Infrastructure.Services
{
    public class PublicReisService
        : IPublicReisService
    {
        private IRepository<Reis, int> _repo;

        public PublicReisService(IRepository<Reis, int> repo)
        {
            _repo = repo;
        }

        public Reis FindPublicReis(int id)
        {
            return _repo.FindPublic(id);
        }

        public IEnumerable<Reis> FindPublicReizen(string userName)
        {
            return _repo.FindAllPublic(userName);
        }
    }
}
