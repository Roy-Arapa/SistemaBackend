using EntidadesVentas.Tipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Tipo
{
    public class TipoDocumentoMap: IEntityTypeConfiguration<DT_TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<DT_TipoDocumento> builder)
        {
            builder.ToTable("DT_TipoDocumento")
                .HasKey(c => c.idTipoDocumento);
        }
    }
}
