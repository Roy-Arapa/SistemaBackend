using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using WebVentas.Modelos.Cliente;
using EntidadesVentas.Cliente;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DbContextVentas _context;

        public ClienteController(DbContextVentas context)
        {
            _context = context;
        }

        // GET: Api/Cliente/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteVW>> Listar()
        {
            var objResultado = from cliente in _context.cliente
                            join tipoDocumento in _context.tipoDocumento on cliente.idTipoDocumento equals tipoDocumento.idTipoDocumento
                            join tipoPersona in _context.tipoPersona on cliente.idTipoPersona equals tipoPersona.idTipoPersona
                            select new
                            {
                                cliente.idCliente,
                                cliente.cNombre,
                                cliente.idTipoDocumento,
                                tipoDocumento.cTipoDocumento,
                                cliente.idTipoPersona,
                                tipoPersona.cTipoPersona,
                                cliente.cDocumento,
                                cliente.cNumeroTelefono,
                                cliente.cCorreoCliente,
                                cliente.lVigente
                            };

            var objClientes = await objResultado.ToListAsync();
            return objClientes.Select(c => new ClienteVW
            {
                idCliente       = c.idCliente,
                cNombre         = c.cNombre,
                idTipoDocumento = c.idTipoDocumento,
                cTipoDocumento  = c.cTipoDocumento,
                idTipoPersona   = c.idTipoPersona,
                cTipoPersona    = c.cTipoPersona,
                cDocumento      = c.cDocumento,
                cNumeroTelefono = c.cNumeroTelefono,
                cCorreoCliente  = c.cCorreoCliente,
                lVigente        = c.lVigente
            });
        }

        // POST: Api/Cliente/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ClienteCrearVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT_Cliente objCliente = new DT_Cliente
            {
                cNombre         = model.cNombre,
                idTipoDocumento = model.idTipoDocumento,
                idTipoPersona   = model.idTipoPersona,
                cDocumento      = model.cDocumento,
                cNumeroTelefono = model.cNumeroTelefono,
                cCorreoCliente  = model.cCorreoCliente.ToLower(),
                idUsuReg        = 0,
                dFechaReg       = DateTime.Now,
                lVigente        = true
            };
            _context.cliente.Add(objCliente);

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

        // PUT: Api/Cliente/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ClienteActualizarVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idCliente <=0)
            {
                return BadRequest();
            }

            var objCliente = await _context.cliente.FirstOrDefaultAsync(c => c.idCliente == model.idCliente);

            if (objCliente == null)
            {
                return NotFound();
            }

            objCliente.cNombre          = model.cNombre;
            objCliente.idTipoDocumento  = model.idTipoDocumento;
            objCliente.idTipoPersona    = model.idTipoPersona;
            objCliente.cDocumento       = model.cDocumento;
            objCliente.cNumeroTelefono  = model.cNumeroTelefono;
            objCliente.cCorreoCliente   = model.cCorreoCliente;
            objCliente.idUsuMod         = 0;
            objCliente.dFechaMod        = DateTime.Now;
            objCliente.lVigente         = model.lVigente;

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

        // PUT: Api/Cliente/Activar/1
        [HttpPut("[action]/{idCliente}")]
        public async Task<IActionResult> Activar([FromRoute] int idCliente)
        {
            if (idCliente <= 0)
            {
                return BadRequest();
            }

            var articulo = await _context.cliente.FirstOrDefaultAsync(a => a.idCliente == idCliente);

            if (articulo == null)
            {
                return NotFound();
            }

            articulo.lVigente = true;

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
        [HttpPut("[action]/{idCliente}")]
        public async Task<IActionResult> Desactivar([FromRoute] int idCliente)
        {
            if (idCliente <= 0)
            {
                return BadRequest();
            }

            var articulo = await _context.cliente.FirstOrDefaultAsync(a => a.idCliente == idCliente);

            if (articulo == null)
            {
                return NotFound();
            }

            articulo.lVigente = false;

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
    }
}
