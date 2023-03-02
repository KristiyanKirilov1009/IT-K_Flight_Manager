using FlightManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManager
{
    public class FlightContext:DbContext
    {
        DbSet<Flight> Flights { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Passanger> Passangers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlightManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasMany(r => r.Reservations)
                .WithOne(f => f.Flight)
                .HasForeignKey(f => f.ReservationID);

            modelBuilder.Entity<Reservation>()
                .HasMany(p => p.Passangers)
                .WithOne(r => r.Reservation)
                .HasForeignKey(r => r.ReservationID);
        }
    }
}
