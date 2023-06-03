using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentas.Ventas
{
    public class DT_DetalleVenta
    {
        public int idDetalleVenta   { get; set; }
        public int idVenta          { get; set; }
        public int idProducto       { get; set; }
        public int nCantidad        { get; set; }
        public decimal nPrecio      { get; set; }
        public decimal nDescuento   { get; set; }
        public int? idUsuReg        { get; set; }
        public DateTime? dFechaReg  { get; set; }
        public int? idUsuMod        { get; set; }
        public DateTime? dFechaMod  { get; set; }
        public bool? lVigente       { get; set; }
        public DT_Venta venta       { get; set; }
        //falta productos
    }
}
