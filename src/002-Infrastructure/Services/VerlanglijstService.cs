using _001_Domain.Entities;
using _001_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.Services
{
    public class VerlanglijstService
        : IVerlanglijstService
    {
        private readonly IRepository<VerlanglijstItem> _itemRepo;
        private readonly IRepository<Verlanglijst> _verlanglijstRepo;

        public VerlanglijstService(IRepository<Verlanglijst> verlanglijstRepo, IRepository<VerlanglijstItem> itemRepo)
        {
            _verlanglijstRepo = verlanglijstRepo;
            _itemRepo = itemRepo;
        }
        public void Add(Verlanglijst item)
        {
            _verlanglijstRepo.Insert(item);
        }

        public void Delete(int id, string userId)
        {
            var toDelete = _verlanglijstRepo.Find(id, userId);
            _verlanglijstRepo.Delete(toDelete);
        }

        public Verlanglijst Get(int id, string userId)
        {
            return _verlanglijstRepo.Find(id, userId);
        }

        public IEnumerable<Verlanglijst> GetAll(string userId)
        {
            return _verlanglijstRepo.FindAll(userId);
        }

        public VerlanglijstItem GetItem(int id, string userId)
        {
            return _itemRepo.Find(id, userId);
        }

        public void Update(Verlanglijst model)
        {
            var verlanglijst = _verlanglijstRepo.Find(model.Id, model.UserId);
            _verlanglijstRepo.Update(verlanglijst);
        }

        public void Update(VerlanglijstItem item)
        {
            var verlanglijst = _verlanglijstRepo.Find(item.Id, item.UserId);
            item.Id = 0;
            verlanglijst.VerlanglijstItems.Add(item);            
            _verlanglijstRepo.Update(verlanglijst);
        }

        public void UpdateItem(VerlanglijstItem item, string v)
        {
            _itemRepo.Update(item);
        }

        public int VerwijderItem(int id, string userId)
        {
            var item = _itemRepo.Find(id, userId);
            var verlanglijst = Get(item.VerlanglijstId, userId);
            _itemRepo.Delete(item);
            return verlanglijst.Id;
        }
    }
}