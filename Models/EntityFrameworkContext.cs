using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models;

public partial class EntityFrameworkContext : DbContext
{
    public EntityFrameworkContext()
    {
    }

    public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Publicacione> Publicaciones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\server; database=EntityFramework; integrated security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Color");
            entity.Property(e => e.Info).HasColumnType("text");
        });

        modelBuilder.Entity<Publicacione>(entity =>
        {
            entity.HasKey(e => e.PublicacionId);

            entity.ToTable("Publicaciones", "LMV");

            entity.Property(e => e.PublicacionId).HasColumnName("PublicacionID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.TcodigoDePublicacionWeb).HasColumnName("TCodigoDePublicacionWeb");
            entity.Property(e => e.TemplateDetalleCompletoId).HasColumnName("TemplateDetalleCompletoID");
            entity.Property(e => e.TpublicacionWebProductoId).HasColumnName("TPublicacionWebProductoID");
            entity.Property(e => e.VigenciaDesde).HasColumnType("datetime");
            entity.Property(e => e.VigenciaHasta).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MVC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
