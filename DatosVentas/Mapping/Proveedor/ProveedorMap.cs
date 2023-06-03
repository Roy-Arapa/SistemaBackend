using EntidadesVentas.Proveedor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatosVentas.Mapping.Proveedor
{
    public  class ProveedorMap: IEntityTypeConfiguration<DT_Proveedor>
    {
        public void Configure(EntityTypeBuilder<DT_Proveedor> builder)
        {
            builder.ToTable("DT_Proveedor")
                .HasKey(p => p.idProveedor);
        }
    }
}
