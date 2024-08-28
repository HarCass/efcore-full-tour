using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EFCore.Data.Scaffold;

public partial class ScaffoldTestContext : DbContext
{
    public ScaffoldTestContext()
    {
    }

    public ScaffoldTestContext(DbContextOptions<ScaffoldTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Test2> Test2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=scaffold_test;uid=;pwd=;sslmode=Preferred", ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Idtest).HasName("PRIMARY");

            entity.ToTable("test");

            entity.Property(e => e.Idtest)
                .ValueGeneratedNever()
                .HasColumnName("idtest");
            entity.Property(e => e.Testcol)
                .HasMaxLength(45)
                .HasColumnName("testcol");
        });

        modelBuilder.Entity<Test2>(entity =>
        {
            entity.HasKey(e => e.Idtest2).HasName("PRIMARY");

            entity.ToTable("test2");

            entity.Property(e => e.Idtest2)
                .ValueGeneratedNever()
                .HasColumnName("idtest2");
            entity.Property(e => e.Test2col).HasColumnName("test2col");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
