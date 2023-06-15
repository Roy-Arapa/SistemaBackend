using EntidadesVentas.Tipo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Tipo
{
    public class TipoComprobanteMap: IEntityTypeConfiguration<DT_TipoComprobante>
    {
        public void Configure(EntityTypeBuilder<DT_TipoComprobante> builder)
        {
            builder.ToTable("DT_TipoComprobante")
                .HasKey(c => c.idTipoComprobante);
        }
    }
}
