using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface IReisService
    {        
        void Add(Reis item);
        IEnumerable<Reis> GetAll(string userId);
        Reis Get(int id, string userId);
        void Update(Reis item);
        void Delete(int id, string userId);
        void AddLand(Land land);
    }
}

