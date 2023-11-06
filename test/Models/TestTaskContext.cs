using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test.Models;

public partial class TestTaskContext : DbContext
{
    public TestTaskContext()
    {
    }

    public TestTaskContext(DbContextOptions<TestTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;database=test_task;port=5432;username=postgres;password=1941");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("brands_pkey");

            entity.ToTable("brands");

            entity.Property(e => e.BrandId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(1, 1, 1, 1231233L, null, 1)
                .HasColumnName("brand_id");
            entity.Property(e => e.BrandActive).HasColumnName("brand_active");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("models_pkey");

            entity.ToTable("models");

            entity.Property(e => e.ModelId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(1, 1, 1, 123123L, null, 1)
                .HasColumnName("model_id");
            entity.Property(e => e.ModelActive).HasColumnName("model_active");
            entity.Property(e => e.ModelBrandId).HasColumnName("model_brand_id");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("model_name");

            entity.HasOne(d => d.ModelBrand).WithMany(p => p.Models)
                .HasForeignKey(d => d.ModelBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mode_brand");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
