namespace MyApp.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using System;

    using Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("Employees");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.FirstName)
                .IsRequired();

            builder
                .Property(e => e.LastName)
                .IsRequired();

            builder
                .HasOne(e => e.Manager)
                .WithMany(m => m.Employees)
                .HasForeignKey(e => e.ManagerId);
        }
    }
}
