using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Data
{
    public class PandaDbContext : IdentityDbContext<PandaUser, PandaRole, string>
    {
        public PandaDbContext(DbContextOptions<IdentityDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(entry =>
            {
                entry.HasKey(p => p.Id);

                entry.HasOne(p => p.Recipient)
                    .WithMany(r => r.Packages)
                    .HasForeignKey(p => p.RecipientId);
            });

            builder.Entity<Receipt>(entry =>
            {
                entry.HasKey(r => r.Id);

                entry.HasOne(r => r.Recipient)
                    .WithMany(u => u.Receipts)
                    .HasForeignKey(r => r.RecipientId);

                entry.HasOne(r => r.Package)
                    .WithOne(p => p.Receipt)
                    .HasForeignKey<Receipt>(r => r.Package)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
