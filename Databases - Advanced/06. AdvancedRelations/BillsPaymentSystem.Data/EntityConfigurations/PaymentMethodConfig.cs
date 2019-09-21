namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using BillsPaymentSystem.Models;

    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .ToTable("PaymentMethods");

            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(p => p.UserId);

            builder
                .HasOne(p => p.BankAccount)
                .WithOne(b => b.PaymentMethod)
                .HasForeignKey<PaymentMethod>(p => p.BankAccountId);

            builder
                .HasOne(p => p.CreditCard)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(p => p.CreditCardId);
        }
    }
}
