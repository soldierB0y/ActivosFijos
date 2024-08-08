using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ActivosFijos.Models;

public partial class ActivosFijosContext : DbContext
{
    public ActivosFijosContext()
    {
    }

    public ActivosFijosContext(DbContextOptions<ActivosFijosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivosFijo> ActivosFijos { get; set; }

    public virtual DbSet<AsientosContable> AsientosContables { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<TiposActivo> TiposActivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DBActivosFijos.mssql.somee.com;initial catalog=DBActivosFijos;TrustServerCertificate=True;user id=SoldierBoy_SQLLogin_1;pwd=k4an7jcnor;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivosFijo>(entity =>
        {
            entity.HasKey(e => e.IdactivosFijos).HasName("PK__ActivosF__CBA78D1FDBA44FA2");

            entity.Property(e => e.IdactivosFijos).HasColumnName("IDActivosFijos");
            entity.Property(e => e.CuentaCompra).HasColumnName("cuentaCompra");
            entity.Property(e => e.CuentaDepreciacion).HasColumnName("cuentaDepreciacion");
            entity.Property(e => e.DepreciacionAcumulada).HasColumnName("depreciacionAcumulada");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");
            entity.Property(e => e.TipoActivo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoActivo");
            entity.Property(e => e.ValorCompra).HasColumnName("valorCompra");

            entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.ActivosFijos)
                .HasForeignKey(d => d.Iddepartamento)
                .HasConstraintName("FK_ActivosFijos_Departamentos");
        });

        modelBuilder.Entity<AsientosContable>(entity =>
        {
            entity.HasKey(e => e.Idasiento).HasName("PK__Asientos__BBE956122D22A701");

            entity.Property(e => e.Idasiento).HasColumnName("IDAsiento");
            entity.Property(e => e.CuentaContable).HasColumnName("cuentaContable");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaAsiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaAsiento");
            entity.Property(e => e.IdtipoInventario).HasColumnName("IDTipoInventario");
            entity.Property(e => e.MontoAsiento).HasColumnName("montoAsiento");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipoMovimiento");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamentos).HasName("PK__Departam__23FC334B19C2227D");

            entity.Property(e => e.Iddepartamentos).HasColumnName("IDDepartamentos");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleados).HasName("PK__Empleado__6128BCAB3DE80D03");

            entity.Property(e => e.Idempleados).HasColumnName("IDEmpleados");
            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.Iddepartamento).HasColumnName("IDDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoPersona");

            entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Iddepartamento)
                .HasConstraintName("FK_Empleados_Departamentos");
        });

        modelBuilder.Entity<TiposActivo>(entity =>
        {
            entity.HasKey(e => e.IdtiposActivos).HasName("PK__TiposAct__2785D0BE3255640E");

            entity.Property(e => e.IdtiposActivos).HasColumnName("IDTiposActivos");
            entity.Property(e => e.CuentaContableCompra).HasColumnName("cuentaContableCompra");
            entity.Property(e => e.CuentaContableDepreciacion).HasColumnName("cuentaContableDepreciacion");
            entity.Property(e => e.Descripicion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripicion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
