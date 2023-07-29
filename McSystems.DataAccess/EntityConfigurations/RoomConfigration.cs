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
    internal class RoomConfigration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {

            builder.ToTable("Room");
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => new {e.Number,e.Floor}).IsUnique();

            builder.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Floor)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(e => e.Capacity)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(e => e.InMaintanance)
                .IsRequired();

        }
    }
}
