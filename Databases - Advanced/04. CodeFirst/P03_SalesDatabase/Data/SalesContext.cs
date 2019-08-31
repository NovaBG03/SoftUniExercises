namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;

    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base()
        {

        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnProductCreating(modelBuilder);
            this.OnCustomerCreating(modelBuilder);
            this.OnStoreCreating(modelBuilder);
            this.OnSaleCreating(modelBuilder);
        }

        private void OnSaleCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                   .Entity<Sale>()
                   .ToTable("Sales");

            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("getdate()");
        }

        private void OnStoreCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .ToTable("Stores");

            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(st => st.Sales)
                .WithOne(sa => sa.Store);
        }

        private void OnCustomerCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .ToTable("Customers");

            modelBuilder
                .Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer);
        }

        private void OnProductCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .ToTable("Products");

            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product);
        }
    }
}
