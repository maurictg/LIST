using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIST.Models;
using Microsoft.EntityFrameworkCore;

namespace LIST.Data
{
    public class LOBContext : DbContext
    {
        public LOBContext(DbContextOptions<LOBContext> options) : base(options)
        {

        }

        public DbSet<Profiles> Profielen { get; set; }
        public DbSet<Profile> Profielkeuze { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profiles>().ToTable("Profiles");
            modelBuilder.Entity<Profile>().ToTable("Profile");
        }
    }
}
