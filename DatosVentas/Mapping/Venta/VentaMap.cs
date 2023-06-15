using EntidadesVentas.Ventas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Venta
{
    public class VentaMap: IEntityTypeConfiguration<DT_Venta>
    {
        public void Configure(EntityTypeBuilder<DT_Venta> builder)
        {
            builder.ToTable("DT_Venta")
                .HasKey(v => v.idVenta);
        }
    }
}
