using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Kestra.KestraDwDb;

public partial class KestraDbContext : DbContext
{
    public KestraDbContext(DbContextOptions<KestraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Invoices");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.CustomerName).HasMaxLength(40);
            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.Salesperson).HasMaxLength(31);
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
