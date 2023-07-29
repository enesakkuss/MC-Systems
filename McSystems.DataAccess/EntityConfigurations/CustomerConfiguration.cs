using McSystems.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.DataAccess.EntityConfigurations
{
    internal class CustomerConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.IdNumber).IsUnique();

            builder.Property(c => c.FirstName)
                .IsRequired()// Not Null
                .IsUnicode() // nvarchar demek
                .HasMaxLength(100); //varchar (100)

            builder.Property(c => c.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(c => c.IdNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(c => c.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.EmailAdress)
                .IsRequired(false)
                .HasColumnType("varchar(150)");

            //builder.HasOne(customer => customer.Country)
            //    .WithMany(country => country.Customers)
            //    .HasForeignKey(customer => customer.Id)
            //    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
