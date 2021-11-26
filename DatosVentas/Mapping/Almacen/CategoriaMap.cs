using EntidadesVentas.Almacen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Almacen
{
    public class CategoriaMap : IEntityTypeConfiguration<Categorías>
    {
        public void Configure(EntityTypeBuilder<Categorías> builder)
        {
            builder.ToTable("Categoria")
                .HasKey(c => c.idcategoria);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
        }
    }
}
