using CatExhibitionWebsite.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatExhibitionWebsite.Data
{
    public class CatContext : DbContext
    {
        public CatContext(DbContextOptions options) 
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
