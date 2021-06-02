using Core.AdditionalTables;
using Core.AppConfig;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ISContext : DbContext
    {
        public ISContext() : base()
        {
            Database.EnsureCreated();
        }

        public ISContext(DbContextOptions<ISContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        //public virtual DbSet<UserShoppingCart> UserShoppingCart { get; set; }
        //public virtual DbSet<UserProductsBought> UserProductsBought { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login).IsRequired();
                entity.Property(e => e.PasswordHashed).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
            });

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany();

            modelBuilder.Entity<UserShoppingCart>().HasKey(usc => new { usc.ProductId, usc.UserId });
            modelBuilder.Entity<UserShoppingCart>().HasOne(usc => usc.User).WithMany(u => u.UserShoppingCart).HasForeignKey(upb => upb.UserId);
            modelBuilder.Entity<UserShoppingCart>().HasOne(usc => usc.Product).WithMany(p => p.UserShoppingCart).HasForeignKey(upb => upb.ProductId);


            modelBuilder.Entity<UserProductsBought>().HasKey(upb => new { upb.ProductId, upb.UserId });
            modelBuilder.Entity<UserProductsBought>().HasOne(upb => upb.User).WithMany(u => u.UserProductsBought).HasForeignKey(upb => upb.UserId);
            modelBuilder.Entity<UserProductsBought>().HasOne(upb => upb.Product).WithMany(p => p.UserProductsBought).HasForeignKey(upb => upb.ProductId);
        }
    }
}
