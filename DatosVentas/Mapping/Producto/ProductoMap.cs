using System;
using System.Collections.Generic;
using System.Text;
using EntidadesVentas.Producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatosVentas.Mapping.Producto
{
    public class ProductoMap : IEntityTypeConfiguration<DT_Producto>
    {
        public void Configure(EntityTypeBuilder<DT_Producto> builder)
        {
            builder.ToTable("DT_Producto")
                .HasKey(c => c.idProducto);
        }
    }
}
