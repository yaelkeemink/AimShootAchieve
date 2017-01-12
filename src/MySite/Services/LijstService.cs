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
        :ILijstService<Lijstje, int>
    {
        private readonly IRepository<Lijstje, int> _lijstRepo;
        private readonly IRepository<LijstItem, int> _lijstItemRepo;

        public LijstService(IRepository<Lijstje, int> lijstRepo, IRepository<LijstItem, int> lijstItemRepo)
        {
            _lijstRepo = lijstRepo;
            _lijstItemRepo = lijstItemRepo;
        }
        public void Add(Lijstje item)
        {
            _lijstRepo.Insert(item);
        }

        public void AddItem(LijstItem item)
        {
            var lijst = Get(item.LijstjeId);
            lijst.Items.Add(item);
            Update(lijst);
        }

        public void Delete(int id)
        {
            var toDelete =_lijstRepo.Find(id);
            _lijstRepo.Delete(toDelete);
        }

        public Lijstje Get(int id)
        {
            return _lijstRepo.Find(id);
        }

        public IEnumerable<Lijstje> GetAll()
        {
            return _lijstRepo.FindAll();
        }

        public int RemoveItem(int itemId)
        {
            var item = _lijstItemRepo.Find(itemId);
            var lijst = _lijstRepo.Find(item.LijstjeId);
            lijst.Items.Remove(item);
            _lijstRepo.Update(lijst);
            return lijst.LijstjeId;
        }

        public void Update(Lijstje item)
        {
            _lijstRepo.Update(item);
        }
    }
}
