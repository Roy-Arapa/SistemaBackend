using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentas.Producto
{
    public class DT_Producto
    {
        public int idProducto { get; set; }
        public string cProducto { get; set; }
        public string cPrecioProd { get; set; }
        public int nCantidadProd { get; set; }
        public string cCodProducto { get; set; }
        public string cDescripcion { get; set; }
        public int idUsuReg { get; set; }
        public DateTime dFechaReg { get; set; }
        public int idUsuMod { get; set; }
        public DateTime? dFechaMod { get; set; }
        public bool lVigente { get; set; }
    }
}
