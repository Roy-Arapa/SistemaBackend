using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentas.Ventas
{
    public class DT_Venta
    {
        public int idVenta              { get; set; }
        public int idCliente            { get; set; }
        public int idUsuario            { get; set; }
        public int idTipoComprobante    { get; set; }
        public string cSerieComprobante { get; set; }
        public string cNumComprobante   { get; set; }
        public decimal nImpuesto        { get; set; }
        public decimal nTotal           { get; set; }
        public int? idUsuReg            { get; set; }
        public DateTime? dFechaReg      { get; set; }
        public int? idUsuMod            { get; set; }
        public DateTime? dFechaMod      { get; set; }
        public bool? lVigente           { get; set; }
        public ICollection<DT_DetalleVenta> detalles { get; set; }
    }
}
