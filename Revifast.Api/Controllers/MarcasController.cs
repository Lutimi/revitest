using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Marca;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public MarcasController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet("[action]")]
        public async Task<IEnumerable<MarcaViewModel>> List()
        {
            var categoryList = await _context.Marcas.ToListAsync();

            return categoryList.Select(c => new MarcaViewModel
            {
                MarcaId = c.MarcaId,
                Nombre = c.Nombre
            });
        }

        // GET: api/Marcas/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<MarcaViewModel>> Show([FromRoute] int id)
        {
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(new MarcaViewModel
            {
                MarcaId = marca.MarcaId,
                Nombre = marca.Nombre
            });
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateMarcaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.MarcaId <= 0)//validando que el categoryid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Marcas.FirstOrDefaultAsync(c => c.MarcaId == model.MarcaId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el categoryid ya esta por defecto
            cat.MarcaId = model.MarcaId;
            cat.Nombre = model.Nombre;

            try
            {
                //palabra reservada
                await _context.SaveChangesAsync();//guardando cambios hacia la bd, siempre se utiliza el try-catch
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Marcas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Marca>> Create([FromBody]CreateMarcaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Marca ca = new Marca
            {
                Nombre = model.Nombre
            };

            _context.Marcas.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Marcas/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            _context.Marcas.Remove(marca);
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
    }
}
