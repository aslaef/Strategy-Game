using Microsoft.EntityFrameworkCore;
using Strategy_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strategy_game.Context
{
  
    public class ApplitactionDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Barrack> Barracks { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Archer> Archers { get; set; }
        public DbSet<Horseman> Horsemans { get; set; }
        public DbSet<Elite> Elites { get; set; }
        public DbSet<Platoon> Platoons { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplitactionDbContext(DbContextOptions<ApplitactionDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
