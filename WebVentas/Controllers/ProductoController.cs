using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using EntidadesVentas.Producto;
using WebVentas.Modelos.Producto;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly DbContextVentas _context;

        public ProductoController(DbContextVentas context)
        {
            _context = context;
        }

        // GET: Api/Producto/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductoListarVM>> Listar()
        {
            var objResultado = from producto in _context.producto
                               select new
                               {
                                   producto.idProducto,
                                   producto.cProducto,
                                   producto.cPrecioProd,
                                   producto.nCantidadProd,
                                   producto.cCodProducto,
                                   producto.cDescripcion,
                                   producto.lVigente
                               };

            var objProducto = await objResultado.ToListAsync();
            return objProducto.Select(c => new ProductoListarVM
            {
                idProducto = c.idProducto,
                cProducto = c.cProducto,
                cPrecioProd = c.cPrecioProd,
                nCantidadProd = c.nCantidadProd,
                cCodProducto = c.cCodProducto,
                cDescripcion = c.cDescripcion,
                lVigente = c.lVigente
            });
        }

        // POST: Api/Producto/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProductoCrearVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT_Producto objProducto = new DT_Producto
            {
                cProducto = model.cProducto,
                cPrecioProd = model.cPrecioProd,
                nCantidadProd = model.nCantidadProd,
                cCodProducto = model.cCodProducto,
                cDescripcion = model.cDescripcion,
                idUsuReg = 0,
                dFechaReg = DateTime.Now,
                lVigente = true
            };
            _context.producto.Add(objProducto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: Api/Producto/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProductoActualizarVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idProducto <= 0)
            {
                return BadRequest();
            }

            var objProducto = await _context.producto.FirstOrDefaultAsync(c => c.idProducto == model.idProducto);

            if (objProducto == null)
            {
                return NotFound();
            }

            objProducto.cProducto = model.cProducto;
            objProducto.cPrecioProd = model.cPrecioProd;
            objProducto.nCantidadProd = model.nCantidadProd;
            objProducto.cCodProducto = model.cCodProducto;
            objProducto.cDescripcion = model.cDescripcion;
            objProducto.idUsuMod = 0;
            objProducto.dFechaMod = DateTime.Now;
            objProducto.lVigente = model.lVigente;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: Api/Producto/Activar/1
        [HttpPut("[action]/{idProducto}")]
        public async Task<IActionResult> Activar([FromRoute] int idProducto)
        {
            if (idProducto <= 0)
            {
                return BadRequest();
            }

            var _producto = await _context.producto.FirstOrDefaultAsync(a => a.idProducto == idProducto);

            if (_producto == null)
            {
                return NotFound();
            }

            _producto.lVigente = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // PUT: Api/Cliente/Desactivar/1
        [HttpPut("[action]/{idProducto}")]
        public async Task<IActionResult> Desactivar([FromRoute] int idProducto)
        {
            if (idProducto <= 0)
            {
                return BadRequest();
            }

            var _producto = await _context.producto.FirstOrDefaultAsync(a => a.idProducto == idProducto);

            if (_producto == null)
            {
                return NotFound();
            }

            _producto.lVigente = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // GET: Api/Producto/BuscarCodigoVenta/5685685
        [HttpGet("[action]/{codigo}")]
        public async Task<IActionResult> BuscarCodigoVenta([FromRoute] string codigo)
        {
            var objProducto = await (from producto in _context.producto
                                     where producto.cCodProducto == codigo && producto.lVigente == true && producto.nCantidadProd > 0
                                     select new
                                     {
                                         producto.idProducto,
                                         producto.cProducto,
                                         producto.cPrecioProd,
                                         producto.nCantidadProd,
                                         producto.cCodProducto,
                                         producto.cDescripcion,
                                         producto.lVigente
                                     }).FirstOrDefaultAsync();

            if (objProducto == null)
            {
                return NotFound();
            }

            return Ok(new ProductoListarVM
            {
                idProducto      = objProducto.idProducto,
                cProducto       = objProducto.cProducto,
                cPrecioProd     = objProducto.cPrecioProd,
                nCantidadProd   = objProducto.nCantidadProd,
                cCodProducto    = objProducto.cCodProducto,
                cDescripcion    = objProducto.cDescripcion,
                lVigente        = objProducto.lVigente
            });
        }

        // GET: Api/Producto/ListarVenta/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ProductoListarVM>> ListarVenta([FromRoute] string texto)
        {
            var objProducto = await (from producto in _context.producto
                                     where producto.cProducto == texto && producto.lVigente == true && producto.nCantidadProd > 0
                                     select new
                                     {
                                         producto.idProducto,
                                         producto.cProducto,
                                         producto.cPrecioProd,
                                         producto.nCantidadProd,
                                         producto.cCodProducto,
                                         producto.cDescripcion,
                                         producto.lVigente
                                     }).ToListAsync();

            return objProducto.Select(p => new ProductoListarVM
            {
                idProducto      = p.idProducto,
                cProducto       = p.cProducto,
                cPrecioProd     = p.cPrecioProd,
                nCantidadProd   = p.nCantidadProd,
                cCodProducto    = p.cCodProducto,
                cDescripcion    = p.cDescripcion,
                lVigente        = p.lVigente
            });
        }
    }
}
