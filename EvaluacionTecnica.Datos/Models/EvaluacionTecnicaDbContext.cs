using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionTecnica.Datos.Models;

public partial class EvaluacionTecnicaDbContext : DbContext
{
    public EvaluacionTecnicaDbContext()
    {
    }

    public EvaluacionTecnicaDbContext(DbContextOptions<EvaluacionTecnicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC074DFEE601");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Nombre, "UQ__Role__75E3EFCF87AC803D").IsUnique();

            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Transaccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioTransaccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())")
                .HasColumnName("Usuario_Transaccion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07D587E5B2");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.UsuarioNombre, "UQ__Usuario__664E680B82DF90C3").IsUnique();

            entity.HasIndex(e => e.Cedula, "UQ__Usuario__B4ADFE38DE2DEB83").IsUnique();

            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Transaccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pasword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioNombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Usuario_Nombre");
            entity.Property(e => e.UsuarioTransaccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_sname())")
                .HasColumnName("Usuario_Transaccion");

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Usuario__RoleId__19DFD96B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
