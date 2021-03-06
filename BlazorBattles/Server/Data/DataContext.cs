using BlazorBattles.Client.Shared;
using BlazorBattles.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Attacker)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Opponent)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Battle>()
                .HasOne(b => b.Winner)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<GoalDay>()
                .Property(d => d.LengthTime)
                .HasConversion(new TimeSpanToTicksConverter());
            
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserUnit> UserUnits { get; set; }

        public DbSet<Battle> Battles { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalDay> GoalDays { get; set; }
    }


}
