using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Distrito;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public DistritosController(DbRevifastContext context)
        {
            _context = context;
        }

        // -------------------- VER LISTA DE DISTRITOS
        // GET: api/Distritos/List
        [HttpGet("[action]")]
        public async Task<IEnumerable<DistritoViewModel>> List()
        {
            var distritoList = await _context.Distritos.ToListAsync();
            return distritoList.Select(d => new DistritoViewModel
            {
                DistritoId = d.DistritoId,
                Nombre = d.Nombre
            });
        }
        // -------------------- VER DISTRITO
        // GET: api/Distritos/Show/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<DistritoViewModel>> Show([FromRoute]int id)
        {
            var distrito = await _context.Distritos.FindAsync(id);

            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(new DistritoViewModel { 
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre
            });
        }

        // -------------------- ACTUALIZAR DISTRITO
        // PUT: api/Distritos/Update/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDistritoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.DistritoId <= 0)
                return BadRequest();

            var dis = await _context.Distritos.FirstOrDefaultAsync(c => c.DistritoId == model.DistritoId);

            if (dis == null)
                return NotFound();

            dis.Nombre = model.Nombre;
            dis.ProvinciaId = model.ProvinciaId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // -------------------- CREAR DISTRITO
        // POST: api/Distritos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Distrito>> Create([FromBody]CreateDistritoViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Distrito ca = new Distrito
            {
                Nombre = model.Nombre,
                ProvinciaId = model.ProvinciaId
            };

            _context.Distritos.Add(ca);//como si escribieras el insert sin ejecutar
            try
            {
                await _context.SaveChangesAsync();//con el savechanges lo aterrizas o actualizar los cambios en la bd
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        // -------------------- ELIMINAR DISTRITO
        // DELETE: api/Distritos/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var distrito = await _context.Distritos.FindAsync(id);
            if (distrito == null)
            {
                return NotFound();
            }
            _context.Distritos.Remove(distrito);
            try
            {
                await _context.SaveChangesAsync();//con el savechanges lo aterrizas o actualizar los cambios en la bd
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        private bool DistritoExists(int id)
        {
            return _context.Distritos.Any(e => e.DistritoId == id);
        }
    }
}
