using _001_Domain.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_Domain.Interfaces
{
    public interface IHomeService
    {
        IndexHomeViewModel GetAantallen(string userId);
    }
}
