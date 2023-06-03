using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVentas.Modelos.Producto
{
    public class ProductoCrearVM
    {
        public string cProducto { get; set; }
        public string cPrecioProd { get; set; }
        public int nCantidadProd { get; set; }
        public string cDescripcion { get; set; }
    }
}
