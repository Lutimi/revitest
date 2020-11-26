using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Conductor;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ConductoresController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Conductores
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConductorViewModel>> List()
        {
            var conductorList = await _context.Conductores.ToListAsync();

            return conductorList.Select(c => new ConductorViewModel
            {
                ConductorId=c.ConductorId,
                Nombre=c.Nombre,
                Apellido=c.Apellido,
                Dni=c.Dni,
                Celular=c.Celular,
                Correo=c.Correo,
                Direccion=c.Direccion
            });
        }

        // GET: api/Conductores/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ConductorViewModel>> Show([FromRoute] int id)
        {
            var conductor= await _context.Conductores.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(new ConductorViewModel
            {
                ConductorId = conductor.ConductorId,
                Nombre = conductor.Nombre,
                Apellido = conductor.Apellido,
                Dni = conductor.Dni,
                Celular = conductor.Celular,
                Correo = conductor.Correo,
                Direccion = conductor.Direccion
            });
        }

        // PUT: api/Conductores/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateConductorViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.ConductorId <= 0)//validando que el categoryid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Conductores.FirstOrDefaultAsync(c => c.ConductorId == model.ConductorId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el categoryid ya esta por defecto
            cat.Nombre = model.Nombre;
            cat.Apellido = model.Apellido;
            cat.Dni = model.Dni;
            cat.Celular = model.Celular;
            cat.Correo = model.Correo;
            cat.Direccion = model.Direccion;

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

        // POST: api/Conductores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody]CreateConductorViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Conductor ca = new Conductor
            {
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Dni = model.Dni,
            Direccion = model.Direccion,
            Celular = model.Celular,
            Correo = model.Correo,
            };

            _context.Conductores.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Conductores/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var conductor = await _context.Conductores.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            _context.Conductores.Remove(conductor);
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

        private bool ConductorExists(int id)
        {
            return _context.Conductores.Any(e => e.ConductorId == id);
        }
    }
}
