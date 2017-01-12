using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.Services.ServiceInterfaces
{
    public interface IService<Entity, Key>
    {
        void Add(Entity item);
        IEnumerable<Entity> GetAll();
        Entity Get(Key id);
        void Update(Entity item);
        void Delete(Key id);
    }
}
