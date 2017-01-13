using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite.DAL
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Reis> Reizen { get; set; }
        public virtual DbSet<Verlanglijstje> Verlanglijstje { get; set; }
        public virtual DbSet<Lijstje> Lijstjes { get; set; }
        public virtual DbSet<LijstItem> LijstItems { get; set; }
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"server=sql2014-1.mijnhostingpartner.nl;Database=Keeminkmydb;uid=Keeminkadmin;password=maggot02;");
                optionsBuilder.UseSqlServer(@"Server =.\\SQLEXPRESS;Database=DATABASENAME;Trusted_Connection=True;");
            }
        }
    }
}