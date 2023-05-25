using EntidadesVentas.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Cliente
{
    public class ClienteMap : IEntityTypeConfiguration<DT_Cliente>
    {
        public void Configure(EntityTypeBuilder<DT_Cliente> builder)
        {
            builder.ToTable("DT_Cliente")
                .HasKey(c => c.idCliente);
        }

    }
}
