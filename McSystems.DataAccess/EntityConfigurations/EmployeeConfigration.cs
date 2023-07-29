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
    internal class EmployeeConfigration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(4);

            builder.Property(c => c.HireDate)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(4);
        }
    }
}
