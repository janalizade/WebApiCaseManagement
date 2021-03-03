using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApp.Models
{
    public partial class WebShopContext : DbContext
    {
        public WebShopContext()
        {
        }

        public WebShopContext(DbContextOptions<WebShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BasketItems> BasketItems { get; set; }
        public virtual DbSet<Baskets> Baskets { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DiscountItems> DiscountItems { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<MembershipTypes> MembershipTypes { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserReviews> UserReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WebShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BasketItems>(entity =>
            {
                entity.HasIndex(e => e.BasketId)
                    .HasName("IX_BasketId");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.BasketId).HasMaxLength(128);

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.BasketId)
                    .HasConstraintName("FK_dbo.BasketItems_dbo.Baskets_BasketId");
            });

            modelBuilder.Entity<Baskets>(entity =>
            {
                entity.HasIndex(e => e.DiscountItemId)
                    .HasName("IX_DiscountItem_Id");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DiscountItemId)
                    .HasColumnName("DiscountItem_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.DiscountItem)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.DiscountItemId)
                    .HasConstraintName("FK_dbo.Baskets_dbo.DiscountItems_DiscountItem_Id");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            modelBuilder.Entity<DiscountItems>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_Product_Id");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.Images_dbo.Products_Product_Id");
            });

            modelBuilder.Entity<MembershipTypes>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<UserReviews>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_Product_Id");

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserReviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.UserReviews_dbo.Products_Product_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
