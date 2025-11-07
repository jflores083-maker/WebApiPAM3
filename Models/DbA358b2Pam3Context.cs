using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiPAM3.Models;

public partial class DbA358b2Pam3Context : DbContext
{
    public DbA358b2Pam3Context()
    {
    }

    public DbA358b2Pam3Context(DbContextOptions<DbA358b2Pam3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SQL8020.site4now.net;Database=db_a358b2_pam3;User Id=db_a358b2_pam3_admin;Password=tudai123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId);

            entity.ToTable("categoria");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC076DEC83C4");

            entity.ToTable("Contacto");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("producto");

            entity.HasIndex(e => e.CategoriaId, "IX_producto_CategoriaId");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos).HasForeignKey(d => d.CategoriaId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07C2E84C88");

            entity.HasIndex(e => e.UserName, "IX_Usuarios_UserName").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValue("Usuario");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
