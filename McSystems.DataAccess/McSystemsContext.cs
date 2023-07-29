using McSystems.DataAccess.Entities;
using McSystems.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystems.DataAccess
{
    public class McSystemsContext:DbContext
    {
        private const string ConnectionString =
            "Server=.;Database=McSystems;Integrated Security=true";
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API
            modelBuilder.Entity<Country>().HasKey(entity => entity.Id);
            modelBuilder.Entity<Country>()
                .Property(c => c.Name) // Name property'sini (kolonunu) yapılandırma
                .IsRequired() //Not NULL
                .HasColumnType("varchar (100)");
            //.IsUnicode(false)
            //.HasMaxLength(100);
            modelBuilder.Entity<Country>().ToTable("Country");

            //Seed Data
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id=1,Name="Türkiye"},
                new Country() { Id=2,Name="İngiltere"},
                new Country() { Id=3,Name="Fransa"},
                new Country() { Id=4,Name="Hollanda"},
                new Country() { Id=5,Name="Arjantin"},
                new Country() { Id=6,Name="Amerika"}
                );

            modelBuilder.Entity<Room>().HasData(
                new Room() { Id = 1, Floor = 1, Number = 1, Capacity = 2, RoomType = RoomType.Luxury },
                new Room() { Id = 2, Floor = 1, Number = 2, Capacity = 2, RoomType = RoomType.Standart },
                new Room() { Id = 3, Floor = 1, Number = 3, Capacity = 4, RoomType = RoomType.Standart },
                new Room() { Id = 4, Floor = 1, Number = 4, Capacity = 4, RoomType = RoomType.Standart },
                new Room() { Id = 5, Floor = 2, Number = 1, Capacity = 2, RoomType = RoomType.Luxury },
                new Room() { Id = 6, Floor = 2, Number = 2, Capacity = 2, RoomType = RoomType.Standart },
                new Room() { Id = 7, Floor = 2, Number = 3, Capacity = 4, RoomType = RoomType.Standart },
                new Room() { Id = 8, Floor = 2, Number = 4, Capacity = 4, RoomType = RoomType.Standart });

            // Customer -> Country arasındaki FK tanımı için gerekli
            // yapılandırmayı Country tarafından bakarak yapsaydım..
            //modelBuilder.Entity<Country>()
            //    .HasMany(country=>country.Customers)
            //    .WithOne(customer => customer.Country)
            //    .HasForeignKey(customer=>customer.CountryId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfigration());
            modelBuilder.ApplyConfiguration(new RoomConfigration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        }
    }
}
