using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Reserva;
using Revifast.Api.Models.ReservaEstado;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ReservasController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet("[action]")]
        public async Task<IEnumerable<ReservaViewModel>> List()//CAMBIAR
        {
            var list = await _context.Reservas.ToListAsync();//CAMBIAR

            return list.Select(c => new ReservaViewModel//CAMBIAR
            {
                ReservaId = c.ReservaId,//CAMBIAR
                Fecha = c.Fecha,
                Hora = c.Hora,
                Observaciones = c.Observaciones,
                Vehiculo = _context.Vehiculos.FindAsync(c.VehiculoId).Result.Placa,
                Local = _context.Locales.FindAsync(c.LocalId).Result.Direccion,
                Estado = _context.ReservaEstados.FindAsync(c.ReservaEstadoId).Result.Estado,
            });
        }

        // GET: api/Reservas/Show/5
        [HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ReservaViewModel>> Show([FromRoute] int id)//CAMBIAR
        {
            var Reserva = await _context.Reservas.FindAsync(id);//CAMBIAR

            if (Reserva == null)//CAMBIAR
            {
                return NotFound();
            }

            return Ok(new ReservaViewModel//CAMBIAR
            {
                ReservaId = Reserva.ReservaId,//CAMBIAR
                //VehiculoId = Reserva.VehiculoId,
                //LocalId = Reserva.LocalId,
                //PagoAdelantadoId = Reserva.PagoAdelantadoId,
                //ReservaEstadoId = Reserva.ReservaEstadoId
            });
        }

        // PUT: api/Reservas/Update/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateReservaViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.ReservaId <= 0)//CAMBIAR
            {
                return BadRequest();
            }

            //CAMBIAR
            var Reserva = await _context.Reservas.FirstOrDefaultAsync(c => c.ReservaId == model.ReservaId);
            if (Reserva == null)//CAMBIAR
            {
                return NotFound();
            }
            //ID POR DEFECTO
            //Reserva.VehiculoId = model.VehiculoId;
            //Reserva.LocalId = model.LocalId;
            //Reserva.PagoAdelantadoId = model.PagoAdelantadoId;
            //Reserva.ReservaEstadoId = model.ReservaEstadoId;

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

        // POST: api/Reservas/Create
        [HttpPost("[action]")]
        public async Task<ActionResult<Reserva>> Create([FromBody]CreateReservaViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Reserva r = new Reserva//CAMBIAR
            {
                Fecha = model.Fecha,
                Hora = model.Hora,
                Observaciones = model.Observaciones,
                VehiculoId = model.VehiculoId,
                LocalId = model.LocalId,
                ReservaEstadoId = model.ReservaEstadoId,
            };

            _context.Reservas.Add(r);//CAMBIAR

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

        // DELETE: api/Reservas/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var r = await _context.Reservas.FindAsync(id); //CAMBIAR
            if (r == null)//CAMBIAR
            {
                return NotFound();
            }
            _context.Reservas.Remove(r);//CAMBIAR
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
    }
}
