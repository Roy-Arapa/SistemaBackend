using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVentas.Modelos.Proveedor
{
    public class ProveedorActualizarVM
    {
        public int idProveedor          { get; set; }
        public string cNombre           { get; set; }
        public int idTipoDocumento      { get; set; }
        public int idTipoPersona        { get; set; }
        public string cDocumento        { get; set; }
        public string cNumeroTelefono   { get; set; }
        public string cDireccion        { get; set; }
        public string cCorreo           { get; set; }
        public int? idUsuMod            { get; set; }
        public DateTime? dFechaMod      { get; set; }

        public ProveedorActualizarVM()
        {
            idProveedor     = 0;
            cNombre         = string.Empty;
            idTipoDocumento = 0;
            idTipoPersona   = 0;
            cDocumento      = string.Empty;
            cNumeroTelefono = string.Empty;
            cDireccion      = string.Empty;
            cCorreo         = string.Empty;
            //idUsuMod      = 0;
            //dFechaMod     = DateTime.Now;
        }
    }
}
