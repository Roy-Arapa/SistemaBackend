using System.Collections.Generic;
using System;

namespace WebVentas.Modelos.Venta
{
    public class VentaCrearVM
    {
        public int idCliente            { get; set; }
        public int idUsuario            { get; set; }
        public int idTipoComprobante    { get; set; }
        public string cSerieComprobante { get; set; }
        public string cNumComprobante   { get; set; }
        public decimal nImpuesto        { get; set; }
        public decimal nTotal           { get; set; }
        public int? idUsuReg            { get; set; }
        public DateTime? dFechaReg      { get; set; }
        public bool? lVigente           { get; set; }
        public List<DetalleVentaVM> detalles { get; set; }
    }
}
