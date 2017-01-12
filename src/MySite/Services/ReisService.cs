using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;
using MySite.DAL;
using MySite.Models.ReisViewModels;
using MySite.Services.ServiceInterfaces;

namespace MySite.Services
{
    public class ReisService
        :IService<Reis, int>
    {
        private IRepository<Reis, int> _repo;
        public ReisService(IRepository<Reis, int> repo)
        {
            _repo = repo;
        }

        public void Add(Reis reis)
        {
            reis.ReisStatus = "Wens";
            _repo.Insert(reis);
        }

        public void Delete(int id)
        {
            var toDelete = _repo.Find(id);
            _repo.Delete(toDelete);
        }

        public Reis Get(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Reis> GetAll()
        {
            return _repo.FindAll();           
        }

        public void Update(Reis reis)
        {
            _repo.Update(reis);
        }
        public void Update(Land land)
        {
            var reis = _repo.Find(land.ReisId);
            reis.Landen.Add(land);
            Update(reis);
        }
    }
}
