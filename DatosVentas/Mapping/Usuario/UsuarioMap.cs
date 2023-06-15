using EntidadesVentas.Usuario;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Usuario
{
    public class UsuarioMap: IEntityTypeConfiguration<DT_Usuario>
    {
        public void Configure(EntityTypeBuilder<DT_Usuario> builder)
        {
            builder.ToTable("DT_Usuario")
                .HasKey(u => u.idUsuario);
        }
    }
}
