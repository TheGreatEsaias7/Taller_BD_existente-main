using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ventas.Models;

public partial class CompraventaContext : DbContext
{
    public CompraventaContext()
    {
    }

    public CompraventaContext(DbContextOptions<CompraventaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Detalleingreso> Detalleingresos { get; set; }

    public virtual DbSet<Detalleventa> Detalleventas { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Idarticulo).HasName("PRIMARY");

            entity.ToTable("articulos");

            entity.HasIndex(e => e.Idcategoria, "idcategoria");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(11)
                .HasColumnName("precio_venta");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("articulos_ibfk_1");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detalleingreso>(entity =>
        {
            entity.HasKey(e => e.IddetalleIngreso).HasName("PRIMARY");

            entity.ToTable("detalleingreso");

            entity.HasIndex(e => e.Idarticulo, "idarticulo");

            entity.HasIndex(e => e.Idingreso, "idingreso");

            entity.Property(e => e.IddetalleIngreso).HasColumnName("iddetalle_ingreso");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Idingreso).HasColumnName("idingreso");
            entity.Property(e => e.Precio)
                .HasPrecision(11)
                .HasColumnName("precio");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.Detalleingresos)
                .HasForeignKey(d => d.Idarticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleingreso_ibfk_2");

            entity.HasOne(d => d.IdingresoNavigation).WithMany(p => p.Detalleingresos)
                .HasForeignKey(d => d.Idingreso)
                .HasConstraintName("detalleingreso_ibfk_1");
        });

        modelBuilder.Entity<Detalleventa>(entity =>
        {
            entity.HasKey(e => e.IddetalleVenta).HasName("PRIMARY");

            entity.ToTable("detalleventas");

            entity.HasIndex(e => e.Idarticulo, "idarticulo");

            entity.HasIndex(e => e.Idventa, "idventa");

            entity.Property(e => e.IddetalleVenta).HasColumnName("iddetalle_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descuento)
                .HasPrecision(11)
                .HasColumnName("descuento");
            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Precio)
                .HasPrecision(11)
                .HasColumnName("precio");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Idarticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalleventas_ibfk_2");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Idventa)
                .HasConstraintName("detalleventas_ibfk_1");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.Idingreso).HasName("PRIMARY");

            entity.ToTable("ingresos");

            entity.HasIndex(e => e.Idproveedor, "idproveedor");

            entity.HasIndex(e => e.Idusuario, "idusuario");

            entity.Property(e => e.Idingreso).HasColumnName("idingreso");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Impuesto)
                .HasPrecision(4)
                .HasColumnName("impuesto");
            entity.Property(e => e.NumComprobante)
                .HasMaxLength(10)
                .HasColumnName("num_comprobante");
            entity.Property(e => e.SerieComprobante)
                .HasMaxLength(7)
                .HasColumnName("serie_comprobante");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasPrecision(11)
                .HasColumnName("total");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.Idproveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingresos_ibfk_1");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ingresos_ibfk_2");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Idpersona).HasName("PRIMARY");

            entity.ToTable("personas");

            entity.Property(e => e.Idpersona).HasColumnName("idpersona");
            entity.Property(e => e.Direccion)
                .HasMaxLength(70)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(20)
                .HasColumnName("num_documento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .HasColumnName("tipo_documento");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(20)
                .HasColumnName("tipo_persona");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Idrol, "idrol");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Direccion)
                .HasMaxLength(70)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'1'")
                .HasColumnType("bit(1)")
                .HasColumnName("estado");
            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(20)
                .HasColumnName("num_documento");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .HasColumnName("tipo_documento");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_ibfk_1");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.Idcliente, "idcliente");

            entity.HasIndex(e => e.Idusuario, "idusuario");

            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Impuesto)
                .HasPrecision(4)
                .HasColumnName("impuesto");
            entity.Property(e => e.NumComprobante)
                .HasMaxLength(10)
                .HasColumnName("num_comprobante");
            entity.Property(e => e.SerieComprobante)
                .HasMaxLength(7)
                .HasColumnName("serie_comprobante");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .HasColumnName("tipo_comprobante");
            entity.Property(e => e.Total)
                .HasPrecision(11)
                .HasColumnName("total");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ventas_ibfk_1");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ventas_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
