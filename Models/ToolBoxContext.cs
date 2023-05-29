using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ToolBoxBlazor.Models;

public partial class ToolBoxContext : DbContext
{
    public ToolBoxContext()
    {
    }

    public ToolBoxContext(DbContextOptions<ToolBoxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoffeeType> CoffeeTypes { get; set; }

    public virtual DbSet<PettyMoney> PettyMoneys { get; set; }

    public virtual DbSet<PettyMoneyRecord> PettyMoneyRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(Program.Configuration.GetConnectionString("ToolBoxDatabase"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CoffeeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coffee_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<PettyMoney>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("petty_money");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Count)
                .HasPrecision(10, 2)
                .HasColumnName("count");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<PettyMoneyRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("petty_money_records");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CoffeeTypeId)
                .HasComment("对应coffee_type表中的id，没有则为空")
                .HasColumnName("coffee_type_id");
            entity.Property(e => e.Count)
                .HasPrecision(10, 2)
                .HasColumnName("count");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.TypeId)
                .HasComment("对应petty_money表中的id")
                .HasColumnName("type_id");
            entity.Property(e => e.VideoName)
                .HasMaxLength(255)
                .HasColumnName("video_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
