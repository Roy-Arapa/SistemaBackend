using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatosVentas;
using EntidadesVentas.Almacen;
using WebVentas.Modelos.Almacen;

namespace WebVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoríasController : ControllerBase
    {
        private readonly DbContextVentas _context;

        public CategoríasController(DbContextVentas context)
        {
            _context = context;
        }

        // GET: api/Categorías/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Listar()
        {
            var categoria = await _context.categorias.ToListAsync();
            return categoria.Select(c => new CategoriaViewModel
            { 
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });
        }

        // GET: api/Categorías/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CategoriaViewModel>> Mostrar(int id)
        {
            var categoria = await _context.categorias.FindAsync(id);
             
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new CategoriaViewModel
            {
                idcategoria = categoria.idcategoria,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion
            });
        }

        // PUT: api/Categorías/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar(ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.categorias.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = model.nombre;
            categoria.descripcion = model.descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar excepcion
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categorías/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Categorías>> Crear(CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categorías categoria = new Categorías
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };

            _context.categorias.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //guardar excepcion
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Categorías/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Categorías>> Eliminar(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoria = await _context.categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.categorias.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //guardar excepcion
                return BadRequest();
            }

            return Ok(categoria);
        }
        // POST: api/Categorías/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar excepcion
                return BadRequest();
            }

            return Ok();
        }
        // POST: api/Categorías/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.categorias.FirstOrDefaultAsync(c => c.idcategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.condicion = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //guardar excepcion
                return BadRequest();
            }

            return Ok();
        }

        private bool CategoríasExists(int id)
        {
            return _context.categorias.Any(e => e.idcategoria == id);
        }
    }
}
