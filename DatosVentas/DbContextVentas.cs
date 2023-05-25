
using DatosVentas.Mapping.Cliente;
using EntidadesVentas.Cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas
{
    public class DbContextVentas : DbContext
    {
        public DbSet<DT_Cliente> cliente { get; set; }
        public DbContextVentas(DbContextOptions<DbContextVentas> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
