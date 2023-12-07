using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VehiclesApi.Models;

public partial class Parcial4dbContext : DbContext
{
    public Parcial4dbContext()
    {
    }

    public Parcial4dbContext(DbContextOptions<Parcial4dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //=> optionsBuilder.UseMySql("server=localhost;user=root;password=admin;database=parcial4db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("vehicles")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(255)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Reserved).HasColumnName("reserved");
            entity.Property(e => e.Year)
                .HasMaxLength(5)
                .HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
