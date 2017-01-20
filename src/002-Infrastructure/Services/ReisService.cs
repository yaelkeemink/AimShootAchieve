using _001_Domain.Entities;
using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services
{
    public class ReisService
        :IReisService
    {
        private IRepository<Reis, int> _repo;
        public ReisService(IRepository<Reis, int> repo)
        {
            _repo = repo;
        }

        public void Add(Reis reis)
        {
            reis.ReisStatus = Status.Wens;
            _repo.Insert(reis);
        }

        public void AddLand(Land land)
        {
            var reis = Get(land.ReisId, land.UserId);
            land.Id = 0;
            land.UserId = reis.UserId;
            reis.Landen.Add(land);
            Update(reis);
        }

        public void Delete(int id, string userId)
        {
            var toDelete = _repo.Find(id, userId);
            _repo.Delete(toDelete);
        }

        public Reis Get(int id, string userId)
        {
            return _repo.Find(id, userId);
        }

        public IEnumerable<Reis> GetAll(string userId)
        {
            return _repo.FindAll(userId);
        }

        public void Update(Reis reis)
        {
            _repo.Update(reis);
        }
        public void Update(Land land)
        {
            var reis = _repo.Find(land.ReisId, land.UserId);
            reis.Landen.Add(land);
            Update(reis);
        }
        public IEnumerable<Reis> GetAllPublic()
        {
            return _repo.FindAllPublic();
        }
    }
}
