using FlightManager.Data.Models;
using FlightManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.Data.Data
{
    public class FlightContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ReservationsPassangers> ReservationsPassangers { get; set; }
        public DbSet<CompaniesUsers> CompaniesUsers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlightManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationsPassangers>()
                .HasKey(rp => new { rp.ReservationID, rp.PassangerID });

            modelBuilder.Entity<ReservationsPassangers>()
                .HasOne(rp => rp.Reservation)
                .WithMany(r => r.ReservationsPassangers)
                .HasForeignKey(rp => rp.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservationsPassangers>()
                .HasOne(rp => rp.Passanger)
                .WithMany(p => p.ReservationsPassangers)
                .HasForeignKey(rp => rp.PassangerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompaniesUsers>()
                .HasKey(cu => new { cu.CompanyID, cu.UserID });

            modelBuilder.Entity<CompaniesUsers>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CompaniesUsers)
                .HasForeignKey(u => u.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompaniesUsers>()
                .HasOne(c => c.Company)
                .WithMany(c => c.CompaniesUsers)
                .HasForeignKey(c => c.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
