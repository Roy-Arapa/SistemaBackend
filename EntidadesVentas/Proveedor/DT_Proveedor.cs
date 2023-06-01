using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentas.Proveedor
{
    public class DT_Proveedor
    {
        public int idProveedor          { get; set; }
        public string cNombre           { get; set; }
        public int idTipoDocumento      { get; set; }
        public int idTipoPersona        { get; set; }
        public string cDocumento        { get; set; }
        public string cNumeroTelefono   { get; set; }
        public string cDireccion        { get; set; }
        public string cCorreo           { get; set; }
        public int? idUsuReg            { get; set; }
        public DateTime? dFechaReg      { get; set; }
        public int? idUsuMod            { get; set; }
        public DateTime? dFechaMod      { get; set; }
        public bool? lVigente           { get; set; }
    }
}
