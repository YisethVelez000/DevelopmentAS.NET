using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentAS.Models;

public partial class DevelopmentAsContext : DbContext
{
    public DevelopmentAsContext()
    {
    }

    public DevelopmentAsContext(DbContextOptions<DevelopmentAsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogoProducto> CatalogoProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<ComprasInsumo> ComprasInsumos { get; set; }

    public virtual DbSet<DetalleOrdenProduccion> DetalleOrdenProduccions { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estampado> Estampados { get; set; }

    public virtual DbSet<EstampadoProducto> EstampadoProductos { get; set; }

    public virtual DbSet<FichasTecInsumo> FichasTecInsumos { get; set; }

    public virtual DbSet<FichasTecnica> FichasTecnicas { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<OrdenProduccion> OrdenProduccions { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosRole> PermisosRoles { get; set; }

    public virtual DbSet<PrivegioPermiso> PrivegioPermisos { get; set; }

    public virtual DbSet<Privilegio> Privilegios { get; set; }

    public virtual DbSet<ProductoTerminado> ProductoTerminados { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogoProducto>(entity =>
        {
            entity.HasKey(e => e.IdcatalogoProducto).HasName("PK_catalogoProducto");

            entity.ToTable("catalogoProductos");

            entity.Property(e => e.IdcatalogoProducto).HasColumnName("idcatalogoProducto");
            entity.Property(e => e.CantidadColor).HasColumnName("cantidadColor");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.IdfichaTecnica).HasColumnName("idfichaTecnica");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreProducto");
            entity.Property(e => e.TipoCatalogo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoCatalogo");
            entity.Property(e => e.TipoEstampado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoEstampado");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdfichaTecnicaNavigation).WithMany(p => p.CatalogoProductos)
                .HasForeignKey(d => d.IdfichaTecnica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fichasTecnicas");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_idCliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoClientes).HasColumnName("estadoClientes");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("nombreCliente");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idUsuario");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Idcompra).HasName("PK_comrpas");

            entity.Property(e => e.Idcompra).HasColumnName("idcompra");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("iva");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("monto");
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreInsumo");
            entity.Property(e => e.NumCompra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numCompra");
            entity.Property(e => e.Recibo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recibo");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proveedor");
        });

        modelBuilder.Entity<ComprasInsumo>(entity =>
        {
            entity.HasKey(e => e.IdCompInsu).HasName("comprasInsumo_pk");

            entity.ToTable("comprasInsumo");

            entity.Property(e => e.IdCompInsu).HasColumnName("idCompInsu");
            entity.Property(e => e.CantidadIns).HasColumnName("cantidadIns");
            entity.Property(e => e.IdCompras).HasColumnName("idCompras");
            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("iva");
            entity.Property(e => e.PrecioUnita)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("precioUnita");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdComprasNavigation).WithMany(p => p.ComprasInsumos)
                .HasForeignKey(d => d.IdCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_compras");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.ComprasInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_insumosCompras");
        });

        modelBuilder.Entity<DetalleOrdenProduccion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleOrdenProduccion).HasName("PK__DetalleO__47138A5921158EF1");

            entity.ToTable("DetalleOrdenProduccion");

            entity.Property(e => e.IdDetalleOrdenProduccion).HasColumnName("idDetalleOrdenProduccion");
            entity.Property(e => e.Productos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tallas)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.NroOrdenProduccionNavigation).WithMany(p => p.DetalleOrdenProduccions)
                .HasForeignKey(d => d.NroOrdenProduccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleOr__NroOr__02FC7413");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_idEmpleado");

            entity.HasIndex(e => e.Cedula, "UC_cedula").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Cedula).HasColumnName("cedula");
            entity.Property(e => e.EstadoEmple)
                .HasDefaultValue(true)
                .HasColumnName("estadoEmple");
            entity.Property(e => e.FechaFinalizacion).HasColumnName("Fecha_Finalizacion");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaNac).HasColumnName("fechaNac");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreEmpleado");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idUsuarioEmpleado");
        });

        modelBuilder.Entity<Estampado>(entity =>
        {
            entity.HasKey(e => e.IdEstampado);

            entity.HasIndex(e => e.NombreEstampado, "UC_Est_nombreEstampado").IsUnique();

            entity.Property(e => e.IdEstampado).HasColumnName("idEstampado");
            entity.Property(e => e.DescripcionEstampado)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descripcionEstampado");
            entity.Property(e => e.EstadoEstampado)
                .HasDefaultValue(true)
                .HasColumnName("estadoEstampado");
            entity.Property(e => e.NombreEstampado)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombreEstampado");
        });

        modelBuilder.Entity<EstampadoProducto>(entity =>
        {
            entity.HasKey(e => e.IdEstampadoProducto).HasName("PK_estampadoProducto");

            entity.Property(e => e.IdEstampadoProducto).HasColumnName("idEstampadoProducto");
            entity.Property(e => e.IdCatalogoP).HasColumnName("idCatalogoP");
            entity.Property(e => e.IdEstampado).HasColumnName("idEstampado");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdCatalogoPNavigation).WithMany(p => p.EstampadoProductos)
                .HasForeignKey(d => d.IdCatalogoP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idCatalogoP");
        });

        modelBuilder.Entity<FichasTecInsumo>(entity =>
        {
            entity.HasKey(e => e.IdFichaTecIns).HasName("PK_idFichaTecIns");

            entity.ToTable("fichasTecInsumos");

            entity.Property(e => e.IdFichaTecIns).HasColumnName("idFichaTecIns");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFicha).HasColumnName("idFicha");
            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");

            entity.HasOne(d => d.IdFichaNavigation).WithMany(p => p.FichasTecInsumos)
                .HasForeignKey(d => d.IdFicha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idFicha");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.FichasTecInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idInsumo");
        });

        modelBuilder.Entity<FichasTecnica>(entity =>
        {
            entity.HasKey(e => e.IdFicha).HasName("PK_fichaTecnica");

            entity.ToTable("fichasTecnicas");

            entity.HasIndex(e => e.NombreFichaTecnica, "UC_nombreFichaTecnica").IsUnique();

            entity.Property(e => e.IdFicha).HasColumnName("idFicha");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.EstadoFicha)
                .HasDefaultValue(true)
                .HasColumnName("estadoFicha");
            entity.Property(e => e.NombreFichaTecnica)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreFichaTecnica");
            entity.Property(e => e.Talla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("talla");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo);

            entity.ToTable("insumos");

            entity.HasIndex(e => e.NombreInsumo, "UC_nombreInsumo").IsUnique();

            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.CantidadInsumo).HasColumnName("cantidadInsumo");
            entity.Property(e => e.EstadoInsumo)
                .HasDefaultValue(true)
                .HasColumnName("estadoInsumo");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.MedidaInsumo)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("medidaInsumo");
            entity.Property(e => e.NombreInsumo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreInsumo");
            entity.Property(e => e.StockInsumo).HasColumnName("stockInsumo");
            entity.Property(e => e.StockMaxInsumo).HasColumnName("stockMaxInsumo");
            entity.Property(e => e.StockMinInsumo).HasColumnName("stockMinInsumo");
            entity.Property(e => e.ValorInsumo).HasColumnName("valorInsumo");
        });

        modelBuilder.Entity<OrdenProduccion>(entity =>
        {
            entity.HasKey(e => e.NroOrdenProduccion).HasName("PK__OrdenPro__E7D0CFDD1790BFF0");

            entity.ToTable("OrdenProduccion");

            entity.Property(e => e.NroOrdenProduccion).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.NumeroPedido);

            entity.ToTable("pedidos");

            entity.Property(e => e.NumeroPedido).HasColumnName("numeroPedido");
            entity.Property(e => e.DireccionEnvio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccionEnvio");
            entity.Property(e => e.EstadoPedido)
                .HasDefaultValue(true)
                .HasColumnName("estadoPedido");
            entity.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaPedido");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("formaPago");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.TotalPedido).HasColumnName("totalPedido");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idCliente");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK_Permiso");

            entity.HasIndex(e => e.NombrePermiso, "UC_Per_nombrePermiso").IsUnique();

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<PermisosRole>(entity =>
        {
            entity.HasKey(e => e.IdPermisoRol).HasName("PK_PermisosRoles");

            entity.ToTable("permisosRoles");

            entity.Property(e => e.IdPermisoRol).HasColumnName("idPermisoRol");
            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_permisos");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles");
        });

        modelBuilder.Entity<PrivegioPermiso>(entity =>
        {
            entity.HasKey(e => e.IdPriPer).HasName("PK_PriPer");

            entity.ToTable("privegioPermiso");

            entity.Property(e => e.IdPriPer).HasColumnName("idPriPer");
            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.IdPrivilegio).HasColumnName("idPrivilegio");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.PrivegioPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_permisosPrivilegio");

            entity.HasOne(d => d.IdPrivilegioNavigation).WithMany(p => p.PrivegioPermisos)
                .HasForeignKey(d => d.IdPrivilegio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_privilegios");
        });

        modelBuilder.Entity<Privilegio>(entity =>
        {
            entity.HasKey(e => e.IdPrivilegio).HasName("PK_Privilegio");

            entity.ToTable("privilegios");

            entity.HasIndex(e => e.NombrePrivilegio, "UC_Pri_nombrePrivilegio").IsUnique();

            entity.Property(e => e.IdPrivilegio).HasColumnName("idPrivilegio");
            entity.Property(e => e.NombrePrivilegio)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombrePrivilegio");
        });

        modelBuilder.Entity<ProductoTerminado>(entity =>
        {
            entity.HasKey(e => e.IdProductoTerminado).HasName("PK_productoTerminado");

            entity.ToTable("ProductoTerminado");

            entity.Property(e => e.IdProductoTerminado).HasColumnName("idProductoTerminado");
            entity.Property(e => e.IdEstampado).HasColumnName("idEstampado");
            entity.Property(e => e.IdFichaTec).HasColumnName("idFichaTec");
            entity.Property(e => e.TipoEstampado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoEstampado");

            entity.HasOne(d => d.IdFichaTecNavigation).WithMany(p => p.ProductoTerminados)
                .HasForeignKey(d => d.IdFichaTec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fichasTec");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK_idProveedor");

            entity.HasIndex(e => e.NombreContac, "UC_nombreContac").IsUnique();

            entity.HasIndex(e => e.NombreProv, "UC_nombreProv").IsUnique();

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoProv)
                .HasDefaultValue(true)
                .HasColumnName("estadoProv");
            entity.Property(e => e.NombreContac)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreContac");
            entity.Property(e => e.NombreProv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreProv");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.HasIndex(e => e.NombreRol, "UC_Rol_nombreRol").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.EstadoRol)
                .HasDefaultValue(true)
                .HasColumnName("estadoRol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_usuario");

            entity.HasIndex(e => e.CorreoElectronico, "UC_correoElectronico").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ConfirmarContrasena)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("confirmarContrasena");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idRol");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.EstadoVenta)
                .HasDefaultValue(true)
                .HasColumnName("estadoVenta");
            entity.Property(e => e.FechaPedido).HasColumnName("fechaPedido");
            entity.Property(e => e.FechaVenta).HasColumnName("fechaVenta");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdPedido).HasColumnName("idPedido");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clientes_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
