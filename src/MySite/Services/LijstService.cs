using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySite.Models;
using MySite.DAL;
using MySite.Services.ServiceInterfaces;

namespace MySite.Services
{
    public class LijstService
        :ILijstService<Lijst, int>
    {
        private readonly IRepository<Lijst, int> _lijstRepo;
        private readonly IRepository<LijstItem, int> _lijstItemRepo;

        public LijstService(IRepository<Lijst, int> lijstRepo, IRepository<LijstItem, int> lijstItemRepo)
        {
            _lijstRepo = lijstRepo;
            _lijstItemRepo = lijstItemRepo;
        }
        public void Add(Lijst item)
        {
            _lijstRepo.Insert(item);
        }

        public void AddItem(LijstItem item)
        {
            var lijst = Get(item.LijstId);
            lijst.Items.Add(item);
            Update(lijst);
        }

        public void Delete(int id)
        {
            var toDelete =_lijstRepo.Find(id);
            _lijstRepo.Delete(toDelete);
        }

        public Lijst Get(int id)
        {
            return _lijstRepo.Find(id);
        }

        public IEnumerable<Lijst> GetAll()
        {
            return _lijstRepo.FindAll();
        }

        public int RemoveItem(int itemId)
        {
            var item = _lijstItemRepo.Find(itemId);
            var lijst = _lijstRepo.Find(item.LijstId);
            lijst.Items.Remove(item);
            _lijstRepo.Update(lijst);
            return lijst.LijstId;
        }

        public void Update(Lijst item)
        {
            _lijstRepo.Update(item);
        }
    }
}
