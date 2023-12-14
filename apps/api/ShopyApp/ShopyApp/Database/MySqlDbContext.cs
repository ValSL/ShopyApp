using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopyApp.Features.Authentication.Models;
using ShopyApp.Features.Carts.Models;
using ShopyApp.Features.Products.Models;

namespace ShopyApp.Database;

public partial class MySqlDbContext : DbContext
{
    public MySqlDbContext()
    {
    }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;database=shopyapp;user=root;password=etereg14");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("cart_pkey");

            entity.ToTable("cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CartOwner).HasColumnName("cart_owner");

            entity.HasOne(d => d.CartOwnerNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CartOwner)
                .HasConstraintName("fk_cart_owner");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("cart_item_pkey");

            entity.ToTable("cart_item");

            entity.Property(e => e.CartItemId).HasColumnName("cart_item_id");
            entity.Property(e => e.ParentCartId).HasColumnName("parent_cart_id");
            entity.Property(e => e.ProductAmount).HasColumnName("product_amount");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.ParentCart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ParentCartId)
                .HasConstraintName("fk_parent_cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_product_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ImageUrl)
                .HasColumnName("image_url");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Owner).WithMany(p => p.Products)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("fk_product_owner");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasColumnName("password_hash");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
