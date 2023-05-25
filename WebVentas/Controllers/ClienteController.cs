using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using WebVentas.Modelos.Cliente;

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

        // GET: api/Cliente/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ClienteVW>> Listar()
        {
            var cliente = await _context.cliente.ToListAsync();
            return cliente.Select(c => new ClienteVW
            {
                idCliente = c.idCliente,
                cNombre = c.cNombre,
                idTipoDocumento = c.idTipoDocumento,
                idTipoPersona = c.idTipoPersona,
                cDocumento = c.cDocumento,
                cNumeroTelefono = c.cNumeroTelefono,
                cCorreoCliente = c.cCorreoCliente
            });
        }
    }
}
