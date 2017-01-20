using _001_Domain.Entities;
using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services
{
    public class VerlanglijstService
        : IService<Verlanglijst, int>
    {
        private IRepository<Verlanglijst, int> _repo;

        public VerlanglijstService(IRepository<Verlanglijst, int> repo)
        {
            _repo = repo;
        }
        public void Add(Verlanglijst item)
        {
            _repo.Insert(item);
        }

        public void Delete(int id, string userId)
        {
            var toDelete = _repo.Find(id, userId);
            _repo.Delete(toDelete);
        }

        public Verlanglijst Get(int id, string userId)
        {
            return _repo.Find(id, userId);
        }

        public IEnumerable<Verlanglijst> GetAll(string userId)
        {
            return _repo.FindAll(userId);
        }



        public void Update(Verlanglijst item)
        {
            _repo.Update(item);
        }
    }
}