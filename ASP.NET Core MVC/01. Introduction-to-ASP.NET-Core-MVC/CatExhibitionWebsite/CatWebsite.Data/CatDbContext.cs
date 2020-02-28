using CatWebsite.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatWebsite.Data
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("Cats");
                entity.HasKey(c => c.Id);
            });
        }
    }
}
