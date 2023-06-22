using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using EntidadesVentas.Ventas;
using WebVentas.Modelos.Venta;
using WebVentas.Modelos.Cliente;
using WebVentas.Modelos.Tipo;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly DbContextVentas _context;

        public VentaController(DbContextVentas context)
        {
            _context = context;
        }

        // GET: Api/Venta/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<VentaVM>> Listar()
        {
            var objResultado = from venta in _context.venta
                               join cliente in _context.cliente on venta.idCliente equals cliente.idCliente
                               join usuario in _context.usuario on venta.idUsuario equals usuario.idUsuario
                               join TipoComprobante in _context.tipoComprobante on venta.idTipoComprobante equals TipoComprobante.idTipoComprobante
                               select new
                               {
                                   venta.idVenta,
                                   venta.idCliente,
                                   cliente.cNombre,
                                   cliente.cDocumento,
                                   cliente.cNumeroTelefono,
                                   cliente.cCorreoCliente,
                                   cliente.cDireccion,
                                   venta.idUsuario,
                                   usuario.cWinUser,
                                   venta.idTipoComprobante,
                                   TipoComprobante.cTipoComprobante,
                                   venta.cSerieComprobante,
                                   venta.cNumComprobante,
                                   venta.nImpuesto,
                                   venta.nTotal,
                                   venta.dFechaReg,
                                   venta.lVigente
                               };

            var objventa = await objResultado.ToListAsync();
            return objventa.Select(v => new VentaVM
            {
                idVenta             = v.idVenta,
                idCliente           = v.idCliente,
                cNombre             = v.cNombre,
                cDocumento          = v.cDocumento,
                cNumeroTelefono     = v.cNumeroTelefono,
                cCorreoCliente      = v.cCorreoCliente,
                cDireccion          = v.cDireccion,
                idUsuario           = v.idUsuario,
                cWinUser            = v.cWinUser,
                idTipoComprobante   = v.idTipoComprobante,
                cTipoComprobante    = v.cTipoComprobante,
                cSerieComprobante   = v.cSerieComprobante,
                cNumComprobante     = v.cNumComprobante,
                nImpuesto           = v.nImpuesto,
                nTotal              = v.nTotal,
                dFechaReg           = v.dFechaReg,
                lVigente            = v.lVigente
            });
        }

        // GET: Api/Venta/ListarFiltro/texto
        [HttpGet("[action]/{cTexto}")]
        public async Task<IEnumerable<VentaVM>> ListarFiltro([FromRoute] string cTexto)
        {
            var objResultado = from venta in _context.venta
                               join cliente in _context.cliente on venta.idCliente equals cliente.idCliente
                               join usuario in _context.usuario on venta.idUsuario equals usuario.idUsuario
                               join TipoComprobante in _context.tipoComprobante on venta.idTipoComprobante equals TipoComprobante.idTipoComprobante
                               where venta.cNumComprobante.Contains(cTexto)
                               orderby venta.idVenta descending
                               select new
                               {
                                   venta.idVenta,
                                   venta.idCliente,
                                   cliente.cNombre,
                                   venta.idUsuario,
                                   usuario.cWinUser,
                                   venta.idTipoComprobante,
                                   TipoComprobante.cTipoComprobante,
                                   venta.cSerieComprobante,
                                   venta.cNumComprobante,
                                   venta.nImpuesto,
                                   venta.nTotal,
                                   venta.lVigente
                               };

            var objventa = await objResultado.ToListAsync();
            return objventa.Select(v => new VentaVM
            {
                idVenta             = v.idVenta,
                idCliente           = v.idCliente,
                cNombre             = v.cNombre,
                idUsuario           = v.idUsuario,
                cWinUser            = v.cWinUser,
                idTipoComprobante   = v.idTipoComprobante,
                cTipoComprobante    = v.cTipoComprobante,
                cSerieComprobante   = v.cSerieComprobante,
                cNumComprobante     = v.cNumComprobante,
                nImpuesto           = v.nImpuesto,
                nTotal              = v.nTotal,
                lVigente            = v.lVigente
            });
        }

        // GET: Api/Venta/ListarDetalles
        [HttpGet("[action]/{idVenta}")]
        public async Task<IEnumerable<DetalleVentaVM>> ListarDetalles([FromRoute] int idVenta)
        {
            var objResultado = from detalleVenta in _context.detalleVenta
                               join producto in _context.producto on detalleVenta.idProducto equals producto.idProducto
                               where detalleVenta.idVenta == idVenta
                               select new
                               {
                                   detalleVenta.idDetalleVenta,
                                   detalleVenta.idVenta,
                                   detalleVenta.idProducto,
                                   producto.cProducto,
                                   detalleVenta.nCantidad,
                                   detalleVenta.nPrecio,
                                   detalleVenta.nDescuento,
                                   producto.cCodProducto
                               };

            var objDetalleVenta = await objResultado.ToListAsync();
            return objDetalleVenta.Select(v => new DetalleVentaVM
            {
                idDetalleVenta  = v.idDetalleVenta,
                idVenta         = v.idVenta,
                idProducto      = v.idProducto,
                cProducto       = v.cProducto,
                nCantidad       = v.nCantidad,
                nPrecio         = v.nPrecio,
                nDescuento      = v.nDescuento,
                cCodProducto    = v.cCodProducto
            });
        }

        // POST: Api/Venta/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] VentaCrearVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT_Venta objVenta = new DT_Venta
            {
                idCliente           = model.idCliente,
                idUsuario           = model.idUsuario,
                idTipoComprobante   = model.idTipoComprobante,
                cSerieComprobante   = model.cSerieComprobante,
                cNumComprobante     = model.cNumComprobante,
                nImpuesto           = model.nImpuesto,
                nTotal              = model.nTotal,
                dFecha              = DateTime.Now,
                idUsuReg            = 0,
                dFechaReg           = DateTime.Now,
                lVigente            = true
            };

            try
            {
                _context.venta.Add(objVenta);
                await _context.SaveChangesAsync();

                var idVenta = objVenta.idVenta;
                foreach (var item in model.detalles)
                {
                    DT_DetalleVenta objDetalleVenta = new DT_DetalleVenta
                    {
                        idVenta     = idVenta,
                        idProducto  = item.idProducto,
                        nCantidad   = item.nCantidad,
                        nPrecio     = item.nPrecio,
                        nDescuento  = item.nDescuento,
                        idUsuReg    = 0,
                        dFechaReg   = DateTime.Now,
                        lVigente    = true
                    };
                    _context.detalleVenta.Add(objDetalleVenta);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: Api/Venta/Anular/1
        [HttpPut("[action]/{idVenta}")]
        public async Task<IActionResult> Anular([FromRoute] int idVenta)
        {
            if (idVenta <= 0)
            {
                return BadRequest();
            }

            var venta = await _context.venta.FirstOrDefaultAsync(v => v.idVenta == idVenta);

            if (venta == null)
            {
                return NotFound();
            }

            venta.lVigente = false;

            try
            {
                await _context.SaveChangesAsync();
                var objDetalle = await _context.detalleVenta.Where(d => d.idVenta == idVenta).ToListAsync();
                foreach (var item in objDetalle)
                {
                    var objProducto             = await _context.producto.FirstOrDefaultAsync(a => a.idProducto == item.idProducto);
                    objProducto.nCantidadProd   = objProducto.nCantidadProd + item.nCantidad;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: Api/Venta/Activar/1
        [HttpPut("[action]/{idVenta}")]
        public async Task<IActionResult> Activar([FromRoute] int idVenta)
        {
            if (idVenta <= 0)
            {
                return BadRequest();
            }

            var objVenta = await _context.venta.FirstOrDefaultAsync(v => v.idVenta == idVenta);

            if (objVenta == null)
            {
                return NotFound();
            }

            objVenta.lVigente = true;

            try
            {
                await _context.SaveChangesAsync();
                var objDetalle = await _context.detalleVenta.Where(d => d.idVenta == idVenta).ToListAsync();
                foreach (var item in objDetalle)
                {
                    var objProducto           = await _context.producto.FirstOrDefaultAsync(a => a.idProducto == item.idProducto);
                    objProducto.nCantidadProd = objProducto.nCantidadProd - item.nCantidad;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // GET: Api/Venta/ConsultaFecha/dFechaIncio/dFechaFin
        [HttpGet("[action]/{dFechaInicio}/{dFechaFin}")]
        public async Task<IEnumerable<VentaVM>> ConsultaFecha([FromRoute] DateTime dFechaInicio, DateTime dFechaFin)
        {
            var objResultado = from venta in _context.venta
                               join cliente in _context.cliente on venta.idCliente equals cliente.idCliente
                               join usuario in _context.usuario on venta.idUsuario equals usuario.idUsuario
                               join TipoComprobante in _context.tipoComprobante on venta.idTipoComprobante equals TipoComprobante.idTipoComprobante
                               where(venta.dFecha >= dFechaInicio && venta.dFecha <= dFechaFin)
                               select new
                               {
                                   venta.idVenta,
                                   venta.idCliente,
                                   cliente.cNombre,
                                   cliente.cDocumento,
                                   cliente.cNumeroTelefono,
                                   cliente.cCorreoCliente,
                                   cliente.cDireccion,
                                   venta.idUsuario,
                                   usuario.cWinUser,
                                   venta.idTipoComprobante,
                                   TipoComprobante.cTipoComprobante,
                                   venta.cSerieComprobante,
                                   venta.cNumComprobante,
                                   venta.nImpuesto,
                                   venta.nTotal,
                                   venta.dFechaReg,
                                   venta.lVigente
                               };

            var objventa = await objResultado.ToListAsync();
            return objventa.Select(v => new VentaVM
            {
                idVenta             = v.idVenta,
                idCliente           = v.idCliente,
                cNombre             = v.cNombre,
                cDocumento          = v.cDocumento,
                cNumeroTelefono     = v.cNumeroTelefono,
                cCorreoCliente      = v.cCorreoCliente,
                cDireccion          = v.cDireccion,
                idUsuario           = v.idUsuario,
                cWinUser            = v.cWinUser,
                idTipoComprobante   = v.idTipoComprobante,
                cTipoComprobante    = v.cTipoComprobante,
                cSerieComprobante   = v.cSerieComprobante,
                cNumComprobante     = v.cNumComprobante,
                nImpuesto           = v.nImpuesto,
                nTotal              = v.nTotal,
                dFechaReg           = v.dFechaReg,
                lVigente            = v.lVigente
            });
        }

        // GET: Api/Venta/ConsultaVentas
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConsultaVM>> ConsultaVentas()
        {
            var objResultado = await _context.venta
                .GroupBy(v => v.dFecha.Month)
                .Select(x => new { cEtiqueta = x.Key, nValor = x.Sum(v => v.nTotal) })
                .OrderByDescending(x => x.cEtiqueta)
                .Take(12)
                .ToListAsync();

            return objResultado.Select(v => new ConsultaVM
            {
                cEtiqueta   = v.cEtiqueta.ToString(),
                nValor      = v.nValor
            });
        }
        private bool DT_VentaExists(int id)
        {
            return _context.venta.Any(e => e.idVenta == id);
        }
    }
}
