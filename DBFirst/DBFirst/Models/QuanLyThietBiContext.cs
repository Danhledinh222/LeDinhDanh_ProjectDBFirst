using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.Models;

public partial class QuanLyThietBiContext : DbContext
{
    public QuanLyThietBiContext()
    {
    }

    public QuanLyThietBiContext(DbContextOptions<QuanLyThietBiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nhom> Nhoms { get; set; }

    public virtual DbSet<ThietBi> ThietBis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LeDinhDanh;Database=QuanLyThietBi;User Id=sa;Password=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nhom>(entity =>
        {
            entity.HasKey(e => e.Manhom).HasName("PK__Nhom__2587AA308364D33A");

            entity.ToTable("Nhom");

            entity.Property(e => e.Manhom)
                .ValueGeneratedNever()
                .HasColumnName("MANHOM");
            entity.Property(e => e.Tennhom)
                .HasMaxLength(200)
                .HasColumnName("TENNHOM");
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.HasKey(e => e.Mathietbi).HasName("PK__ThietBi__AF9850EDA2312947");

            entity.ToTable("ThietBi");

            entity.Property(e => e.Mathietbi)
                .ValueGeneratedNever()
                .HasColumnName("MATHIETBI");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Manhom).HasColumnName("MANHOM");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tenthietbi)
                .HasMaxLength(200)
                .HasColumnName("TENTHIETBI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
