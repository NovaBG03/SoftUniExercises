namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using BillsPaymentSystem.Models;

    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .ToTable("CreditCards");

            builder
                .HasKey(c => c.CreditCardId);

            builder
                .Ignore(c => c.LimitLeft);
        }
    }
}
