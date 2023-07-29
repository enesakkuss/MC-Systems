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
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.HasKey(r => r.Id);

            builder.HasOne<Room>()
                .WithMany()
                .HasForeignKey(r => r.RoomId);

            builder.Property(r => r.StartDate)
                .HasColumnType("date");

            builder.Property(r => r.EndDate)
                .HasColumnType("date");
        }
    }
}
