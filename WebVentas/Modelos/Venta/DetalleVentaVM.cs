using System;

namespace WebVentas.Modelos.Venta
{
    public class DetalleVentaVM
    {
        public int idDetalleVenta   {get; set;}
        public int idVenta          { get; set; }
        public int idProducto       { get; set; }
        public string cProducto     { get; set; }
        public int nCantidad        { get; set; }
        public decimal nPrecio      { get; set; }
        public decimal nDescuento   { get; set; }
        public String cCodProducto { get; set; }
    }
}
