using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVentas.Modelos.Cliente
{
    public class ClienteCrearVM
    {
        public string cNombre           { get; set; }
        public int idTipoDocumento      { get; set; }
        public int idTipoPersona        { get; set; }
        public string cDocumento        { get; set; }
        public string cNumeroTelefono   { get; set; }
        public string cCorreoCliente    { get; set; }
        public string cDireccion        { get; set; }
        //public int? idUsuReg            { get; set; }
        //public DateTime? dFechaReg      { get; set; }
        //public int? idUsuMod            { get; set; }
        //public DateTime? dFechaMod      { get; set; }
        //public bool lVigente            { get; set; }

        public ClienteCrearVM()
        {
            cNombre         = string.Empty;
            idTipoDocumento = 0;
            idTipoPersona   = 0;
            cDocumento      = string.Empty;
            cNumeroTelefono = string.Empty;
            cCorreoCliente  = string.Empty;
            cDireccion      = string.Empty;
            //idUsuReg        = 0;
            //dFechaReg       = DateTime.Now;
            //idUsuMod        = 0;
            //dFechaMod       = DateTime.Now;
            //lVigente        = true;
        }
    }
}
