namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using BillsPaymentSystem.Models;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .ToTable("BankAccounts");

            builder
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(b => b.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
