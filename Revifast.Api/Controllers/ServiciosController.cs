using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Servicio;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ServiciosController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Servicios
        [HttpGet("[action]")]
        public async Task<IEnumerable<ServicioViewModel>> List()
        {
            var ServicioList = await _context.Servicios.ToListAsync();

            return ServicioList.Select(c => new ServicioViewModel
            {
               ServicioId=c.ServicioId,
               Nombre=c.Nombre,
               Descripcion=c.Descripcion,
               LocalId=c.LocalId,
               CategoriaId=c.CategoriaId,
               Promocion = _context.Promociones.FindAsync(c.ServicioId).Result.Nombre
            });
        }

        // GET: api/Servicios/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ServicioViewModel>> Show([FromRoute] int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return Ok(new ServicioViewModel
            {
                ServicioId = servicio.ServicioId,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                LocalId = servicio.LocalId,
                CategoriaId = servicio.CategoriaId,
                //PromocionId = servicio.PromocionId
            });
        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateServicioViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.ServicioId <= 0)//validando que el Servicioid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Servicios.FirstOrDefaultAsync(c => c.ServicioId == model.ServicioId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el Servicioid ya esta por defecto
            cat.Nombre = model.Nombre;
            cat.Descripcion = model.Descripcion;
            cat.LocalId = model.LocalId;
            cat.CategoriaId = model.CategoriaId;
            //cat.PromocionId = model.PromocionId;

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

        // POST: api/Servicios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Servicio>> Create([FromBody]CreateServicioViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Servicio ca = new Servicio
            {
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
            LocalId = model.LocalId,
            CategoriaId = model.CategoriaId,
            //PromocionId = model.PromocionId
        };

            _context.Servicios.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Servicios/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var Servicio = await _context.Servicios.FindAsync(id);
            if (Servicio == null)
            {
                return NotFound();
            }
            _context.Servicios.Remove(Servicio);
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

        private bool ServicioExists(int id)
        {
            return _context.Servicios.Any(e => e.ServicioId == id);
        }
    }
}
