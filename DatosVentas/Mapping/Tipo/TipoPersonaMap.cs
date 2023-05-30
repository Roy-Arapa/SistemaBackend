using EntidadesVentas.Tipo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Tipo
{
    public class TipoPersonaMap: IEntityTypeConfiguration<DT_TipoPersona>
    {
        public void Configure(EntityTypeBuilder<DT_TipoPersona> builder)
        {
            builder.ToTable("DT_TipoPersona")
                .HasKey(c => c.idTipoPersona);
        }
    }
}
