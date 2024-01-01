﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuaRevenda.Data;

#nullable disable

namespace SuaRevenda.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SuaRevenda.Models.CommissionTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ConsignedId")
                        .HasColumnType("bigint");

                    b.Property<long>("Ratio")
                        .HasColumnType("bigint");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConsignedId")
                        .IsUnique();

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("CommissionTables");
                });

            modelBuilder.Entity("SuaRevenda.Models.Origin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.HasKey("Id");

                    b.ToTable("Origins");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Origin");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SuaRevenda.Models.Piece", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OriginId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.HasIndex("UserId");

                    b.ToTable("Pieces");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Piece");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SuaRevenda.Models.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("SuaRevenda.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SuaRevenda.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuaRevenda.Models.Consigned", b =>
                {
                    b.HasBaseType("SuaRevenda.Models.Origin");

                    b.HasDiscriminator().HasValue("Consigned");
                });

            modelBuilder.Entity("SuaRevenda.Models.Purchase", b =>
                {
                    b.HasBaseType("SuaRevenda.Models.Origin");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasDiscriminator().HasValue("Purchase");
                });

            modelBuilder.Entity("SuaRevenda.Models.PieceSold", b =>
                {
                    b.HasBaseType("SuaRevenda.Models.Piece");

                    b.Property<long>("SaleId")
                        .HasColumnType("bigint");

                    b.HasIndex("SaleId");

                    b.HasDiscriminator().HasValue("PieceSold");
                });

            modelBuilder.Entity("SuaRevenda.Models.CommissionTable", b =>
                {
                    b.HasOne("SuaRevenda.Models.Consigned", "Consigned")
                        .WithOne("CommissionTable")
                        .HasForeignKey("SuaRevenda.Models.CommissionTable", "ConsignedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuaRevenda.Models.Supplier", "Supplier")
                        .WithOne("CommissionTable")
                        .HasForeignKey("SuaRevenda.Models.CommissionTable", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consigned");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SuaRevenda.Models.Piece", b =>
                {
                    b.HasOne("SuaRevenda.Models.Origin", "Origin")
                        .WithMany("Pieces")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuaRevenda.Models.User", "User")
                        .WithMany("Pieces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Origin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuaRevenda.Models.Sale", b =>
                {
                    b.HasOne("SuaRevenda.Models.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SuaRevenda.Models.PieceSold", b =>
                {
                    b.HasOne("SuaRevenda.Models.Sale", "Sale")
                        .WithMany("PiecesSold")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("SuaRevenda.Models.Origin", b =>
                {
                    b.Navigation("Pieces");
                });

            modelBuilder.Entity("SuaRevenda.Models.Sale", b =>
                {
                    b.Navigation("PiecesSold");
                });

            modelBuilder.Entity("SuaRevenda.Models.Supplier", b =>
                {
                    b.Navigation("CommissionTable")
                        .IsRequired();
                });

            modelBuilder.Entity("SuaRevenda.Models.User", b =>
                {
                    b.Navigation("Pieces");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("SuaRevenda.Models.Consigned", b =>
                {
                    b.Navigation("CommissionTable")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
