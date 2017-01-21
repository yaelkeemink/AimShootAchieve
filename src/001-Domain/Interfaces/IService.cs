using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface IService<Entity>
        where Entity :class
    {
        void Add(Entity item);
        IEnumerable<Entity> GetAll(string userId);
        Entity Get(int id, string userId);
        void Update(Entity item);
        void Delete(int id, string userId);
    }
}
