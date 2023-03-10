using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MokkiApp.Models;

public partial class MokkiAppDbContext : DbContext
{
    public MokkiAppDbContext()
    {
    }

    public MokkiAppDbContext(DbContextOptions<MokkiAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceStatus> PlaceStatuses { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Work> Works { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC27C1D15BE6");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Job__3214EC27321EE7F6");

            entity.ToTable("Job");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Job__CategoryID__6A30C649");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Place__3214EC27E446FDA7");

            entity.ToTable("Place");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Job).WithMany(p => p.Places)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Place__JobID__6D0D32F4");
        });

        modelBuilder.Entity<PlaceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlaceSta__3214EC27AAEC32A6");

            entity.ToTable("PlaceStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Place).WithMany(p => p.PlaceStatuses)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("FK__PlaceStat__Place__70DDC3D8");

            entity.HasOne(d => d.Worker).WithMany(p => p.PlaceStatuses)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("FK__PlaceStat__Worke__6FE99F9F");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Profile");

            entity.Property(e => e.Avatar)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Worker).WithMany()
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("FK__Profile__WorkerI__74AE54BC");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC27206FD5C0");

            entity.ToTable("Reservation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BlobUrl)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("BlobURL");
            entity.Property(e => e.Diet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Interests)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

            entity.HasOne(d => d.Season).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("FK__Reservati__Seaso__6477ECF3");

            entity.HasOne(d => d.Worker).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("FK__Reservati__Worke__656C112C");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Season__3214EC275BBBD325");

            entity.ToTable("Season");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Season1)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("Season");
        });

        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Work__3214EC27A3FCD75C");

            entity.ToTable("Work");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Duration)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Equipment)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Importancy)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            entity.Property(e => e.WorkName)
                .HasMaxLength(800)
                .IsUnicode(false);

            entity.HasOne(d => d.Season).WithMany(p => p.Works)
                .HasForeignKey(d => d.SeasonId)
                .HasConstraintName("FK__Work__SeasonID__5EBF139D");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Worker__3214EC27BAE79E68");

            entity.ToTable("Worker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WorkId).HasColumnName("WorkID");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Work).WithMany(p => p.Workers)
                .HasForeignKey(d => d.WorkId)
                .HasConstraintName("FK__Worker__WorkID__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
