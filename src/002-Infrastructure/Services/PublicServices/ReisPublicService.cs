using _001_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _001_Domain.Interfaces;

namespace _002_Infrastructure.Services.PublicServices
{
    public class ReisPublicService
        : BasePublicService<Reis>
    {
        public ReisPublicService(IRepository<Reis> repo) 
            : base(repo)
        {
        }
        public override IEnumerable<Reis> FindPublic(string userName)
        {
            return base.FindPublic(userName)
                .OrderByDescending(a => a.ReisStatus)
                .ThenBy(a => a.AankomstDatum)
                .ThenBy(a => a.Naam);
                
        }
    }
}
