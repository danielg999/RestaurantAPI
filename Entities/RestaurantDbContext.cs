using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        // Możliwości: Konfiguracja do połączenie do bazy danych, definicja dodatkowych właściwości dla kolumn w bazie danych

        private string _connectionString = "Server=DESKTOP-P46VLN4;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Nadpisywanie właściwości dla kolumn w bazie
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Precyzowanie typu bazy danych do użycia oraz jak powinno wyglądać do niej połączenie
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
