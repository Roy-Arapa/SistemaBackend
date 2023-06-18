using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVentas.Modelos.Cliente
{
    public class ClienteVW
    {
        public int idCliente            { get; set; }
        public string cNombre           { get; set; }
        public int idTipoDocumento      { get; set; }
        public string cTipoDocumento    { get; set; }
        public string cTipoPersona      { get; set; }
        public int idTipoPersona        { get; set; }
        public string cDocumento        { get; set; }
        public string cNumeroTelefono   { get; set; }
        public string cCorreoCliente    { get; set; }
        public string cDireccion        { get; set; }
        public bool lVigente            { get; set; }
    }
}
