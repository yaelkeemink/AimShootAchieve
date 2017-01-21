using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _001_Domain.Interfaces
{
    public interface IPublicService<Entity>
        where Entity : BaseEntity
    {
        IEnumerable<Entity> FindPublicReizen(string userId);
        Entity FindPublicReis(int id);
    }
}
