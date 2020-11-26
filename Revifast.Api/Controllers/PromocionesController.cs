using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Promocion;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public PromocionesController(DbRevifastContext context)
        {
            _context = context;
        }
        
        // GET: api/ReservaDetalles
        [HttpGet("[action]")]
        public async Task<IEnumerable<PromocionViewModel>> List()//CAMBIAR
        {
            var promocionList = await _context.Promociones.ToListAsync();//CAMBIAR

            return promocionList.Select(c => new PromocionViewModel//CAMBIAR
            {
                PromocionId = c.PromocionId,//CAMBIAR
                Nombre = c.Nombre,
                Descuento = c.Descuento,
                Descripcion = c.Descripcion,
                ServicioId=c.ServicioId
            });
        }

        // GET: api/ReservaDetalles/Show/5
        [HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PromocionViewModel>> Show([FromRoute] int id)//CAMBIAR
        {
            var promocion = await _context.Promociones.FindAsync(id);//CAMBIAR

            if (promocion == null)//CAMBIAR
            {
                return NotFound();
            }

            return Ok(new PromocionViewModel//CAMBIAR
            {
                PromocionId = promocion.PromocionId,//CAMBIAR
                Nombre = promocion.Nombre,
                Descuento = promocion.Descuento,
                Descripcion = promocion.Descripcion
               
            });
        }

        // PUT: api/ReservaDetalles/Update/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePromocionViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.PromocionId <= 0)//CAMBIAR
            {
                return BadRequest();
            }

            //CAMBIAR
            var promocion = await _context.Promociones.FirstOrDefaultAsync(c => c.PromocionId == model.PromocionId);
            if (promocion == null)//CAMBIAR
            {
                return NotFound();
            }
            //ID POR DEFECTO
            promocion.Nombre = model.Nombre;//CAMBIAR
            promocion.Descuento = model.Descuento;
            promocion.Descripcion = model.Descripcion;
            promocion.ServicioId = model.ServicioId;

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

        // POST: api/ReservaDetalles/Create
        [HttpPost("[action]")]
        public async Task<ActionResult<Promocion>> Create([FromBody]CreatePromocionViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Promocion promocion = new Promocion//CAMBIAR
            {
                Nombre = model.Nombre,//CAMBIAR
                Descuento = model.Descuento,
                Descripcion = model.Descripcion,
                ServicioId=model.ServicioId
               
            };


            _context.Promociones.Add(promocion);//CAMBIAR
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

        // DELETE: api/ReservaDetalles/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var r = await _context.Promociones.FindAsync(id); //CAMBIAR
            if (r == null)//CAMBIAR
            {
                return NotFound();
            }
            _context.Promociones.Remove(r);//CAMBIAR
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
