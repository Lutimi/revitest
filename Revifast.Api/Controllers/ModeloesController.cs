using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Modelo;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloesController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ModeloesController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Modeloes
        [HttpGet("[action]")]
        public async Task<IEnumerable<ModeloViewModel>> List()
        {
            var modeloList = await _context.Modelos.ToListAsync();

            return modeloList.Select(c => new ModeloViewModel
            {
              ModeloId=c.ModeloId,
              Nombre=c.Nombre,
              MarcaId=c.MarcaId
            });
        }

        // GET: api/Modeloes/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ModeloViewModel>> Show([FromRoute] int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(new ModeloViewModel
            {
                ModeloId = modelo.ModeloId,
                Nombre = modelo.Nombre,
                MarcaId = modelo.MarcaId
            });
        }

        // PUT: api/Modeloes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateModeloViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.ModeloId <= 0)//validando que el categoryid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Modelos.FirstOrDefaultAsync(c => c.ModeloId == model.ModeloId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el categoryid ya esta por defecto
            cat.Nombre = model.Nombre;
            cat.MarcaId = model.MarcaId;

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

        // POST: api/Modeloes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Modelo>> Create([FromBody]CreateModeloViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Modelo ca = new Modelo
            {
                Nombre = model.Nombre,
                MarcaId = model.MarcaId
        };

            _context.Modelos.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Modeloes/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var category = await _context.Modelos.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Modelos.Remove(category);
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

        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.ModeloId == id);
        }
    }
}
