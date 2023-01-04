using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Claims;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Configuration;
using SkiProject.Infrastructure.Data.Models.Shop;

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

            modelBuilder.Entity<PlaceToStay>()
           .HasOne<City>(s => s.City)
           .WithMany(g => g.PlacesToStay)
           .HasForeignKey(s => s.CityId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
            .HasOne<PlaceToStay>(s => s.PlaceToStay)
            .WithMany(ad => ad.Reservations)
            .HasForeignKey(s => s.PlaceToStayId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
            .HasOne<ApplicationUser>(s => s.User)
            .WithMany(ad => ad.Reservations)
            .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
            .HasOne<Slope>(s => s.Slope)
            .WithOne(ad => ad.City)
            .HasForeignKey<Slope>(ad => ad.CityId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ForumTopic>()
                .HasMany(g => g.Posts)
                .WithOne(s => s.Topic)
                .HasForeignKey(f => f.TopicId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(g => g.Posts)
                .WithOne(s => s.User)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(g => g.CreatedTopics)
                .WithOne(s => s.CreatedByUser)
                .HasForeignKey(f => f.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(g => g.CreatedAdvertisments)
                .WithOne(s => s.User)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(g => g.CreatedProducts)
                .WithOne(s => s.User)
                .HasForeignKey(f => f.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>()
                .HasOne(u => u.User)
                .WithMany(a => a.CreatedProducts)
                .HasForeignKey(k => k.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Product>()
            //    .HasMany(g => g.ProductImages)
            //    .WithOne(s => s.Product)
            //    .HasForeignKey(f => f.ProductId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(g => g.Messages)
                .WithOne(s => s.Receiver)
                .HasForeignKey(f => f.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ForumTopic>()
                .HasOne(u => u.CreatedByUser)
                .WithMany(t => t.CreatedTopics)
                .HasForeignKey(u => u.CreatedByUserId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ForumTopic>().HasIndex(u => u.Title).IsUnique();
            modelBuilder.Entity<Advertisment>().HasIndex(u => u.Title).IsUnique();

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new SlopeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceToStayConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);


        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PlaceToStay> PlaceToStays { get; set; }
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ForumTopic> Topics { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}