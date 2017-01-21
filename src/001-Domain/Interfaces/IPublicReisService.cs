using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Entities;

namespace _001_Domain.Interfaces
{
    public interface IPublicReisService
    {
        IEnumerable<Reis> FindPublicReizen(string v);
        Reis FindPublicReis(int id);
    }
}
