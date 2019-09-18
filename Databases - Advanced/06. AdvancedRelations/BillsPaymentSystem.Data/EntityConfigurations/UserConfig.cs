﻿namespace BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    using BillsPaymentSystem.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
