using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Claims;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models;

namespace SkiProject.Infrastructure.Data

{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
            .HasOne<UserBankCard>(s => s.BankCard)
            .WithOne(ad => ad.User)
            .HasForeignKey<UserBankCard>(ad => ad.UserId);

            modelBuilder.Entity<ApplicationUser>()
            .HasOne<Wallet>(b => b.Wallet)
            .WithOne(i => i.User)
            .HasForeignKey<Wallet>(b => b.UserId);
            modelBuilder.Entity<Wallet>().Property(a => a.AmountInWallet).HasPrecision(18, 2);

            modelBuilder.Entity<PlaceToStay>()
           .HasOne<City>(s => s.City)
           .WithMany(g => g.PlacesToStay)
           .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Reservation>()
            .HasOne<PlaceToStay>(s => s.PlaceToStay)
            .WithMany(ad => ad.Reservations)
            .HasForeignKey(s => s.PlaceToStayId);
            
            modelBuilder.Entity<Reservation>()
            .HasOne<ApplicationUser>(s => s.User)
            .WithMany(ad => ad.Reservations)
            .HasForeignKey(s => s.UserId);

            base.OnModelCreating(modelBuilder);
           
                
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserBankCard> BankCards { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PlaceToStay> PlaceToStays { get; set; }
    }
}