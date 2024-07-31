using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecordStore.Models;

public partial class RecordshopContext : DbContext
{
    public RecordshopContext()
    {
    }

    public RecordshopContext(DbContextOptions<RecordshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Release> Releases { get; set; }

    public virtual DbSet<ReleaseType> ReleaseTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=recordshop;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.ToTable("Artist");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Artists)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Artist_Category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.ToTable("Medium");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Release>(entity =>
        {
            entity.ToTable("Release");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Runtime)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Artist).WithMany(p => p.Releases)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Release_Artist");

            entity.HasOne(d => d.Medium).WithMany(p => p.Releases)
                .HasForeignKey(d => d.MediumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Release_Medium");

            entity.HasOne(d => d.ReleaseType).WithMany(p => p.Releases)
                .HasForeignKey(d => d.ReleaseTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Release_ReleaseType");
        });

        modelBuilder.Entity<ReleaseType>(entity =>
        {
            entity.ToTable("ReleaseType");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
