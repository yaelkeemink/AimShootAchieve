using _001_Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
