﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SipItApp.API.Models;

namespace SipItApp.API.Migrations
{
    [DbContext(typeof(SipitContext))]
    partial class sipitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SipItApp.API.Models.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("base_name_key");

                    b.ToTable("base");
                });

            modelBuilder.Entity("SipItApp.API.Models.Flavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Isenergy")
                        .HasColumnName("isenergy")
                        .HasColumnType("boolean");

                    b.Property<bool>("Isfresh")
                        .HasColumnName("isfresh")
                        .HasColumnType("boolean");

                    b.Property<bool>("Ispuree")
                        .HasColumnName("ispuree")
                        .HasColumnType("boolean");

                    b.Property<bool>("Issugarfree")
                        .HasColumnName("issugarfree")
                        .HasColumnType("boolean");

                    b.Property<bool>("Issyrup")
                        .HasColumnName("issyrup")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("flavor");
                });

            modelBuilder.Entity("SipItApp.API.Models.Sanpetefavorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Baseid")
                        .HasColumnName("baseid")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Baseid");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("sanpetefavorites_name_key");

                    b.ToTable("sanpetefavorites");
                });

            modelBuilder.Entity("SipItApp.API.Models.SanpetefavoritesFlavor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("FlavorId")
                        .HasColumnName("flavor_id")
                        .HasColumnType("integer");

                    b.Property<int?>("SanpetefavoritesId")
                        .HasColumnName("sanpetefavorites_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FlavorId");

                    b.HasIndex("SanpetefavoritesId");

                    b.ToTable("sanpetefavorites_flavor");
                });

            modelBuilder.Entity("SipItApp.API.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("money");

                    b.Property<int>("Volume")
                        .HasColumnName("volume")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("size_name_key");

                    b.HasIndex("Price")
                        .IsUnique()
                        .HasName("size_price_key");

                    b.HasIndex("Volume")
                        .IsUnique()
                        .HasName("size_volume_key");

                    b.ToTable("size");
                });

            modelBuilder.Entity("SipItApp.API.Models.Sanpetefavorites", b =>
                {
                    b.HasOne("SipItApp.API.Models.Base", "Base")
                        .WithMany("Sanpetefavorites")
                        .HasForeignKey("Baseid")
                        .HasConstraintName("sanpetefavorites_baseid_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SipItApp.API.Models.SanpetefavoritesFlavor", b =>
                {
                    b.HasOne("SipItApp.API.Models.Flavor", "Flavor")
                        .WithMany("SanpetefavoritesFlavor")
                        .HasForeignKey("FlavorId")
                        .HasConstraintName("sanpetefavorites_flavor_flavor_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SipItApp.API.Models.Sanpetefavorites", "Sanpetefavorites")
                        .WithMany("SanpetefavoritesFlavor")
                        .HasForeignKey("SanpetefavoritesId")
                        .HasConstraintName("sanpetefavorites_flavor_sanpetefavorites_id_fkey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
