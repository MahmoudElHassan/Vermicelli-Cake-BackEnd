﻿// <auto-generated />
using System;
using E_Commerce_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce_DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240326222446_categoryPictureUrl")]
    partial class categoryPictureUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce_DAL.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_Commerce_DAL.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("E_Commerce_DAL.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeliveryMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Commerce_DAL.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("E_Commerce_DAL.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Commerce_DAL.Order", b =>
                {
                    b.HasOne("E_Commerce_DAL.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId");

                    b.OwnsOne("E_Commerce_DAL.OrderAggregate.Address", "ShipToAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("Building")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Flat")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryMethod");

                    b.Navigation("ShipToAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce_DAL.OrderItem", b =>
                {
                    b.HasOne("E_Commerce_DAL.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("E_Commerce_DAL.ProductItemOrdered", "ItemOrdered", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("int");

                            b1.Property<string>("PictureUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ProductItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ProductName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ItemOrdered");
                });

            modelBuilder.Entity("E_Commerce_DAL.Product", b =>
                {
                    b.HasOne("E_Commerce_DAL.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("E_Commerce_DAL.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
