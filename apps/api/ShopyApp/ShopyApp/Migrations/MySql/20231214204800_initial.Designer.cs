﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopyApp.Database;

#nullable disable

namespace ShopyApp.Migrations.MySql
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20231214204800_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShopyApp.Features.Authentication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password_hash");

                    b.HasKey("UserId")
                        .HasName("users_pkey");

                    b.HasIndex(new[] { "Email" }, "users_email_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ShopyApp.Features.Carts.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cart_id");

                    b.Property<int?>("CartOwner")
                        .HasColumnType("int")
                        .HasColumnName("cart_owner");

                    b.HasKey("CartId")
                        .HasName("cart_pkey");

                    b.HasIndex("CartOwner");

                    b.ToTable("cart", (string)null);
                });

            modelBuilder.Entity("ShopyApp.Features.Carts.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cart_item_id");

                    b.Property<int?>("ParentCartId")
                        .HasColumnType("int")
                        .HasColumnName("parent_cart_id");

                    b.Property<int?>("ProductAmount")
                        .HasColumnType("int")
                        .HasColumnName("product_amount");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("total_price");

                    b.HasKey("CartItemId")
                        .HasName("cart_item_pkey");

                    b.HasIndex("ParentCartId");

                    b.HasIndex("ProductId");

                    b.ToTable("cart_item", (string)null);
                });

            modelBuilder.Entity("ShopyApp.Features.Products.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("image_url");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("owner_id");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("ProductId")
                        .HasName("products_pkey");

                    b.HasIndex("OwnerId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("ShopyApp.Features.Carts.Models.Cart", b =>
                {
                    b.HasOne("ShopyApp.Features.Authentication.Models.User", "CartOwnerNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("CartOwner")
                        .HasConstraintName("fk_cart_owner");

                    b.Navigation("CartOwnerNavigation");
                });

            modelBuilder.Entity("ShopyApp.Features.Carts.Models.CartItem", b =>
                {
                    b.HasOne("ShopyApp.Features.Carts.Models.Cart", "ParentCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ParentCartId")
                        .HasConstraintName("fk_parent_cart");

                    b.HasOne("ShopyApp.Features.Products.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_product_id");

                    b.Navigation("ParentCart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopyApp.Features.Products.Models.Product", b =>
                {
                    b.HasOne("ShopyApp.Features.Authentication.Models.User", "Owner")
                        .WithMany("Products")
                        .HasForeignKey("OwnerId")
                        .HasConstraintName("fk_product_owner");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ShopyApp.Features.Authentication.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopyApp.Features.Carts.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ShopyApp.Features.Products.Models.Product", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
