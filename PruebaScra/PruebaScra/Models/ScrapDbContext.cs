using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaScra.Models;

public partial class ScrapDbContext : DbContext
{
    public ScrapDbContext()
    {
    }

    public ScrapDbContext(DbContextOptions<ScrapDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compra> Compras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-PPN13H4;Initial Catalog=ScrapDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
