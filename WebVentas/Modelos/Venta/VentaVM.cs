using System.Collections.Generic;
using System;

namespace WebVentas.Modelos.Venta
{
    public class VentaVM
    {
        public int idVenta              { get; set; }
        public int idCliente            { get; set; }
        public string cNombre           { get; set; }
        public string cDocumento        { get; set; }
        public string cNumeroTelefono   { get; set; }
        public string cCorreoCliente    { get; set; }
        public string cDireccion        { get; set; }
        public int idUsuario            { get; set; }
        public string cWinUser          { get; set; }
        public int idTipoComprobante    { get; set; }
        public string cTipoComprobante  { get; set; }
        public string cSerieComprobante { get; set; }
        public string cNumComprobante   { get; set; }
        public decimal nImpuesto        { get; set; }
        public decimal nTotal           { get; set; }
        public DateTime? dFechaReg      { get; set; }
        public bool? lVigente           { get; set; }
    }
}
