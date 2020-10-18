using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SipItApp.API.Models
{
    public partial class sipitContext : DbContext
    {
        public sipitContext()
        {
        }

        public sipitContext(DbContextOptions<sipitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<Flavor> Flavor { get; set; }
        public virtual DbSet<Sanpetefavorites> Sanpetefavorites { get; set; }
        public virtual DbSet<SanpetefavoritesFlavor> SanpetefavoritesFlavor { get; set; }
        public virtual DbSet<Size> Size { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5430;Database=sipit;Username=postgres;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Base>(entity =>
            {
                entity.ToTable("base");

                entity.HasIndex(e => e.Name)
                    .HasName("base_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Flavor>(entity =>
            {
                entity.ToTable("flavor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Isenergy).HasColumnName("isenergy");

                entity.Property(e => e.Isfresh).HasColumnName("isfresh");

                entity.Property(e => e.Ispuree).HasColumnName("ispuree");

                entity.Property(e => e.Issugarfree).HasColumnName("issugarfree");

                entity.Property(e => e.Issyrup).HasColumnName("issyrup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Sanpetefavorites>(entity =>
            {
                entity.ToTable("sanpetefavorites");

                entity.HasIndex(e => e.Name)
                    .HasName("sanpetefavorites_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Baseid).HasColumnName("baseid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.Sanpetefavorites)
                    .HasForeignKey(d => d.Baseid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sanpetefavorites_baseid_fkey");
            });

            modelBuilder.Entity<SanpetefavoritesFlavor>(entity =>
            {
                entity.ToTable("sanpetefavorites_flavor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlavorId).HasColumnName("flavor_id");

                entity.Property(e => e.SanpetefavoritesId).HasColumnName("sanpetefavorites_id");

                entity.HasOne(d => d.Flavor)
                    .WithMany(p => p.SanpetefavoritesFlavor)
                    .HasForeignKey(d => d.FlavorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sanpetefavorites_flavor_flavor_id_fkey");

                entity.HasOne(d => d.Sanpetefavorites)
                    .WithMany(p => p.SanpetefavoritesFlavor)
                    .HasForeignKey(d => d.SanpetefavoritesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sanpetefavorites_flavor_sanpetefavorites_id_fkey");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.HasIndex(e => e.Name)
                    .HasName("size_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.Price)
                    .HasName("size_price_key")
                    .IsUnique();

                entity.HasIndex(e => e.Volume)
                    .HasName("size_volume_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Volume).HasColumnName("volume");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
