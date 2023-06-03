
using DatosVentas.Mapping.Cliente;
<<<<<<< HEAD
using DatosVentas.Mapping.Producto;
using DatosVentas.Mapping.Tipo;
using EntidadesVentas.Cliente;
using EntidadesVentas.Producto;
=======
using DatosVentas.Mapping.Proveedor;
using DatosVentas.Mapping.Tipo;
using EntidadesVentas.Cliente;
using EntidadesVentas.Proveedor;
>>>>>>> d756c2bc4586d6740b27c259db65f239a9b2a75e
using EntidadesVentas.Tipo;
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
<<<<<<< HEAD
        public DbSet<DT_Producto> producto { get; set; }
=======
        public DbSet<DT_Proveedor> proveedor { get; set; }
>>>>>>> d756c2bc4586d6740b27c259db65f239a9b2a75e
        public DbContextVentas(DbContextOptions<DbContextVentas> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
            modelBuilder.ApplyConfiguration(new TipoPersonaMap());
<<<<<<< HEAD
            modelBuilder.ApplyConfiguration(new ProductoMap());
=======
            modelBuilder.ApplyConfiguration(new ProveedorMap());
>>>>>>> d756c2bc4586d6740b27c259db65f239a9b2a75e
        }
    }
}
