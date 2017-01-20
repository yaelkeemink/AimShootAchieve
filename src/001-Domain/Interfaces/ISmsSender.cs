using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _001_AimShootAchieve.Domain.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
