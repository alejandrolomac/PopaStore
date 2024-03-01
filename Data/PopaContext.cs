using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PopaStore.Data
{
    public class PopaDBContext : DbContext
    {
        public PopaDBContext(DbContextOptions<PopaDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<StoreUserRelation> StoreUserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreUserRelation>()
                .HasKey(sur => sur.Id);
        }

    }

}
