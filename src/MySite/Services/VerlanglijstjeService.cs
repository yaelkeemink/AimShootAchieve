using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;
using MySite.DAL;
using MySite.Services.ServiceInterfaces;

namespace MySite.Services
{
    public class VerlanglijstjeService
        :IService<Verlanglijstje, int>
    {
        private IRepository<Verlanglijstje, int> _repo;

        public VerlanglijstjeService(IRepository<Verlanglijstje, int> repo)
        {
            _repo = repo;
        }
        public void Add(Verlanglijstje item)
        {
            _repo.Insert(item);
        }

        public void Delete(int id)
        {
            var toDelete =_repo.Find(id);
            _repo.Delete(toDelete);
        }

        public Verlanglijstje Get(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Verlanglijstje> GetAll()
        {
            return _repo.FindAll();
        }

        

        public void Update(Verlanglijstje item)
        {
            _repo.Update(item);
        }
    }
}
