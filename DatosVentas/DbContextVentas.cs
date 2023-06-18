
using DatosVentas.Mapping.Cliente;
using DatosVentas.Mapping.Producto;
using DatosVentas.Mapping.Proveedor;
using DatosVentas.Mapping.Tipo;
using DatosVentas.Mapping.Usuario;
using DatosVentas.Mapping.Venta;
using EntidadesVentas.Cliente;
using EntidadesVentas.Producto;
using EntidadesVentas.Proveedor;
using EntidadesVentas.Tipo;
using EntidadesVentas.Usuario;
using EntidadesVentas.Ventas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas
{
    public class DbContextVentas : DbContext
    {
        public DbSet<DT_Cliente> cliente { get; set; }
        public DbSet<DT_TipoDocumento> tipoDocumento { get; set; }
        public DbSet<DT_TipoPersona> tipoPersona { get; set; }
        public DbSet<DT_Proveedor> proveedor { get; set; }
        public DbSet<DT_Producto> producto { get; set; }
        public DbSet<DT_Venta> venta { get; set; }
        public DbSet<DT_DetalleVenta> detalleVenta { get; set; }
        public DbSet<DT_Usuario> usuario { get; set; }
        public DbSet<DT_TipoComprobante> tipoComprobante { get; set; }
        public DbContextVentas(DbContextOptions<DbContextVentas> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new TipoPersonaMap());
            modelBuilder.ApplyConfiguration(new ProveedorMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new VentaMap());
            modelBuilder.ApplyConfiguration(new DetalleVentaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TipoComprobanteMap());
        }
    }
}
