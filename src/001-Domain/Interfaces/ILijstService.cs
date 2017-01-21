using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface ILijstService
    {
        void Add(Lijst item);
        IEnumerable<Lijst> GetAll(string userId);
        Lijst Get(int id, string userId);
        void Update(Lijst item);
        void AddItem(LijstItem item);
        int RemoveItem(int item, string userId);
        void Delete(int id, string userId);
    }
}
