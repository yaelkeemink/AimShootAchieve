using _001_Domain.Entities;
using _002_AimShootAchieve.Infrastructure.DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_Infrastructure.DAL
{
    public class DatabaseInitializer
    {
        public static void Initialize(UserManager<ApplicationUser> userManager)
        {
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "Jane"
                },
                new ApplicationUser()
                {
                    UserName = "Youri"
                },
                new ApplicationUser()
                {
                    UserName = "Ela"
                },
                new ApplicationUser()
                {
                    UserName = "Louis"
                },
                new ApplicationUser()
                {
                    UserName = "Yael"
                }
            };
            foreach (var user in users)
            {
                userManager.CreateAsync(user, "welkom");
            }
        }
    }
}
