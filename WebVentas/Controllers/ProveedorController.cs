using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using WebVentas.Modelos.Proveedor;
using EntidadesVentas.Proveedor;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly DbContextVentas _context;

        public ProveedorController(DbContextVentas context)
        {
            _context = context;
        }
        // GET: Api/Proveedor/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProveedorVM>> Listar()
        {
            var objResultado = from proveedor in _context.proveedor
                               join tipoDocumento in _context.tipoDocumento on proveedor.idTipoDocumento equals tipoDocumento.idTipoDocumento
                               join tipoPersona in _context.tipoPersona on proveedor.idTipoPersona equals tipoPersona.idTipoPersona
                               select new
                               {
                                   proveedor.idProveedor,
                                   proveedor.cNombre,
                                   proveedor.idTipoDocumento,
                                   tipoDocumento.cTipoDocumento,
                                   proveedor.idTipoPersona,
                                   tipoPersona.cTipoPersona,
                                   proveedor.cDocumento,
                                   proveedor.cNumeroTelefono,
                                   proveedor.cDireccion,
                                   proveedor.cCorreo,
                                   proveedor.lVigente
                               };

            var objProveedor = await objResultado.ToListAsync();
            return objProveedor.Select(p => new ProveedorVM
            {
                idProveedor     = p.idProveedor,
                cNombre         = p.cNombre,
                idTipoDocumento = p.idTipoDocumento,
                cTipoDocumento  = p.cTipoDocumento,
                idTipoPersona   = p.idTipoPersona,
                cTipoPersona    = p.cTipoPersona,
                cDocumento      = p.cDocumento,
                cNumeroTelefono = p.cNumeroTelefono,
                cDireccion      = p.cDireccion,
                cCorreo         = p.cCorreo,
                lVigente        = p.lVigente
            });
        }

        // POST: Api/Proveedor/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ProveedorCrearVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT_Proveedor objProveedor = new DT_Proveedor
            {
                cNombre         = model.cNombre,
                idTipoDocumento = model.idTipoDocumento,
                idTipoPersona   = model.idTipoPersona,
                cDocumento      = model.cDocumento,
                cNumeroTelefono = model.cNumeroTelefono,
                cDireccion      = model.cDireccion,
                cCorreo         = model.cCorreo.ToLower(),
                idUsuReg        = 0,
                dFechaReg       = DateTime.Now,
                lVigente        = true
            };
            _context.proveedor.Add(objProveedor);

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

        // PUT: Api/Proveedor/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProveedorActualizarVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idProveedor <= 0)
            {
                return BadRequest();
            }

            var objCliente = await _context.proveedor.FirstOrDefaultAsync(p => p.idProveedor == model.idProveedor);

            if (objCliente == null)
            {
                return NotFound();
            }

            objCliente.cNombre          = model.cNombre;
            objCliente.idTipoDocumento  = model.idTipoDocumento;
            objCliente.idTipoPersona    = model.idTipoPersona;
            objCliente.cDocumento       = model.cDocumento;
            objCliente.cNumeroTelefono  = model.cNumeroTelefono;
            objCliente.cDireccion       = model.cDireccion;
            objCliente.cCorreo          = model.cCorreo;
            objCliente.idUsuMod         = 0;
            objCliente.dFechaMod        = DateTime.Now;

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

        // PUT: Api/Proveedor/Activar/1
        [HttpPut("[action]/{idProveedor}")]
        public async Task<IActionResult> Activar([FromRoute] int idProveedor)
        {
            if (idProveedor <= 0)
            {
                return BadRequest();
            }

            var proveedor = await _context.proveedor.FirstOrDefaultAsync(a => a.idProveedor == idProveedor);

            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.lVigente = true;

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

        // PUT: Api/Proveedor/Desactivar/1
        [HttpPut("[action]/{idProveedor}")]
        public async Task<IActionResult> Desactivar([FromRoute] int idProveedor)
        {
            if (idProveedor <= 0)
            {
                return BadRequest();
            }

            var proveedor = await _context.proveedor.FirstOrDefaultAsync(a => a.idProveedor == idProveedor);

            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.lVigente = false;

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

        private bool DT_ProveedorExists(int id)
        {
            return _context.proveedor.Any(e => e.idProveedor == id);
        }
    }
}
