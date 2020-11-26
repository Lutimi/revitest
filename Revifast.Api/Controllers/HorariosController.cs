using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Horario;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public HorariosController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Horarios
        [HttpGet("[action]")]
        public async Task<IEnumerable<HorarioViewModel>> List()
        {
            var horarioList = await _context.Horarios.ToListAsync();

            return horarioList.Select(c => new HorarioViewModel
            {
                HorarioId = c.HorarioId,
                HoraApertura = c.HoraApertura,
                HoraCierre = c.HoraCierre
            });
        }

        // GET: api/Horarios/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<HorarioViewModel>> Show([FromRoute] int id)
        {
            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            return Ok(new HorarioViewModel
            {
                HorarioId = horario.HorarioId,
                HoraApertura = horario.HoraApertura,
                HoraCierre = horario.HoraCierre
            });
        }

        // PUT: api/Horarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateHorarioViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.HorarioId <= 0)//validando que el Horarioid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Horarios.FirstOrDefaultAsync(c => c.HorarioId == model.HorarioId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el Horarioid ya esta por defecto
            cat.HoraApertura = model.HoraApertura;
            cat.HoraCierre = model.HoraCierre;

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

        // POST: api/Horarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Horario>> Create([FromBody]CreateHorarioViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Horario ca = new Horario
            {
                HoraApertura = model.HoraApertura,
                HoraCierre = model.HoraCierre
            };

            _context.Horarios.Add(ca);//como si escribieras el insert sin ejecutar
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


        // DELETE: api/Horarios/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            _context.Horarios.Remove(horario);
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

