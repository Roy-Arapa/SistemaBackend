using DatosVentas.Mapping.Almacen;
using EntidadesVentas.Almacen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas
{
    public class DbContextVentas : DbContext
    {
        public DbSet<Categorías> categorias { get; set; }
        public DbContextVentas(DbContextOptions<DbContextVentas> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
