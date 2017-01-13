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
        :IService<Verlanglijst, int>
    {
        private IRepository<Verlanglijst, int> _repo;

        public VerlanglijstjeService(IRepository<Verlanglijst, int> repo)
        {
            _repo = repo;
        }
        public void Add(Verlanglijst item)
        {
            _repo.Insert(item);
        }

        public void Delete(int id)
        {
            var toDelete =_repo.Find(id);
            _repo.Delete(toDelete);
        }

        public Verlanglijst Get(int id)
        {
            return _repo.Find(id);
        }

        public IEnumerable<Verlanglijst> GetAll()
        {
            return _repo.FindAll();
        }

        

        public void Update(Verlanglijst item)
        {
            _repo.Update(item);
        }
    }
}
