using EntidadesVentas.Ventas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Venta
{
    public class DetalleVentaMap: IEntityTypeConfiguration<DT_DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DT_DetalleVenta> builder)
        {
            builder.ToTable("DT_DetalleVenta")
                .HasKey(d => d.idDetalleVenta);
        }
    }
}
