using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Control_Transacciones_BD3.Models;

public partial class ModeloDatos2Context : DbContext
{
    public ModeloDatos2Context()
    {
    }

    public ModeloDatos2Context(DbContextOptions<ModeloDatos2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneroMusical> GeneroMusicals { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-TPHMI6R;Initial Catalog=Modelo_Datos2;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneroMusical>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__genero_m__3213E83F6F3BDC0C");

            entity.ToTable("genero_musical");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreGeneroMusical)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreGeneroMusical");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__nacional__3213E83F6E0D322E");

            entity.ToTable("nacionalidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreNacionalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombreNacionalidad");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__persona__3213E83F73C2931A");

            entity.ToTable("persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdGeneroMusical).HasColumnName("idGeneroMusical");
            entity.Property(e => e.IdNacionalidad).HasColumnName("idNacionalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdGeneroMusicalNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdGeneroMusical)
                .HasConstraintName("FK__persona__idGener__3B75D760");

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdNacionalidad)
                .HasConstraintName("FK__persona__idNacio__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
