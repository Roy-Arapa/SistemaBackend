using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using EntidadesVentas.Tipo;
using WebVentas.Modelos.Tipo;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly DbContextVentas _context;

        public TipoController(DbContextVentas context)
        {
            _context = context;
        }

        // GET: Api/Tipo/ListarTipoDoc
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoDocumentoVM>> ListarTipoDoc()
        {
            var tipoDocumento = await _context.tipoDocumento
                .Where(t => t.lVigente == true)
                .ToListAsync();

            return tipoDocumento.Select(t => new TipoDocumentoVM
            {
                idTipoDocumento = t.idTipoDocumento,
                cTipoDocumento  = t.cTipoDocumento,
            });
        }

        // GET: Api/Tipo/ListarTipoPer
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoPersonaVM>> ListarTipoPer()
        {
            var tipoPersona = await _context.tipoPersona
                .Where(t => t.lVigente == true)
                .ToListAsync();
            
            return tipoPersona.Select(t => new TipoPersonaVM
            {
                idTipoPersona = t.idTipoPersona,
                cTipoPersona  = t.cTipoPersona,
            });
        }

        // GET: Api/Tipo/ListarTipoComp
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoComprobanteVM>> ListarTipoComp()
        {
            var tipoComprobante = await _context.tipoComprobante
                .Where(t => t.lVigente == true)
                .ToListAsync();

            return tipoComprobante.Select(t => new TipoComprobanteVM
            {
                idTipoComprobante = t.idTipoComprobante,
                cTipoComprobante  = t.cTipoComprobante,
            });
        }

        private bool DT_TipoDocumentoExists(int id)
        {
            return _context.tipoDocumento.Any(e => e.idTipoDocumento == id);
        }
    }
}
