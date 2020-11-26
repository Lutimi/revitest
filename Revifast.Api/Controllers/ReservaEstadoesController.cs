using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.ReservaEstado;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaEstadoesController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ReservaEstadoesController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/ReservaEstados
        [HttpGet("[action]")]
        public async Task<IEnumerable<ReservaEstadoViewModel>> List()//CAMBIAR
        {
            var ReservaEstadoList = await _context.ReservaEstados.ToListAsync();//CAMBIAR

            return ReservaEstadoList.Select(c => new ReservaEstadoViewModel//CAMBIAR
            {
                ReservaEstadoId = c.ReservaEstadoId,//CAMBIAR
                Estado = c.Estado
            });
        }

        // GET: api/ReservaEstados/Show/5
        [HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ReservaEstadoViewModel>> Show([FromRoute] int id)//CAMBIAR
        {
            var ReservaEstado = await _context.ReservaEstados.FindAsync(id);//CAMBIAR

            if (ReservaEstado == null)//CAMBIAR
            {
                return NotFound();
            }

            return Ok(new ReservaEstadoViewModel//CAMBIAR
            {
                ReservaEstadoId = ReservaEstado.ReservaEstadoId,//CAMBIAR
                Estado = ReservaEstado.Estado
            });
        }

        // PUT: api/ReservaEstados/Update/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateReservaEstadoViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.ReservaEstadoId <= 0)//CAMBIAR
            {
                return BadRequest();
            }

            //CAMBIAR
            var ReservaEstado = await _context.ReservaEstados.FirstOrDefaultAsync(c => c.ReservaEstadoId == model.ReservaEstadoId);
            if (ReservaEstado == null)//CAMBIAR
            {
                return NotFound();
            }
            //ID POR DEFECTO
            ReservaEstado.Estado = model.Estado;//CAMBIAR

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

        // POST: api/ReservaEstados/Create
        [HttpPost("[action]")]
        public async Task<ActionResult<ReservaEstado>> Create([FromBody]CreateReservaEstadoViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ReservaEstado ReservaEstado = new ReservaEstado//CAMBIAR
            {
                Estado = model.Estado//CAMBIAR
            };


            _context.ReservaEstados.Add(ReservaEstado);//CAMBIAR
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

        // DELETE: api/ReservaEstados/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var r = await _context.ReservaEstados.FindAsync(id); //CAMBIAR
            if (r == null)//CAMBIAR
            {
                return NotFound();
            }
            _context.ReservaEstados.Remove(r);//CAMBIAR
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
