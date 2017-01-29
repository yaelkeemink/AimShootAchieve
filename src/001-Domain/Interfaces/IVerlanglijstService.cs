using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface IVerlanglijstService
        : IDisposable
    {
        void Add(Verlanglijst item);
        IEnumerable<Verlanglijst> GetAll(string userId);
        Verlanglijst Get(int id, string userId);
        void Update(Verlanglijst model);
        void Update(VerlanglijstItem item);
        void Delete(int id, string userId);
        int VerwijderItem(int id, string userId);
        VerlanglijstItem GetItem(int id, string userId);
        void UpdateItem(VerlanglijstItem item, string v);
    }
}
