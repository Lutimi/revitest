using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Distrito;
using Revifast.Api.Models.Local;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalsController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public LocalsController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Locals
        [HttpGet("[action]")]
        public async Task<IEnumerable<LocalViewModel>> List()
        {
            var localList = await _context.Locales.ToListAsync();

            return localList.Select(c => new LocalViewModel
            {
                LocalId = c.LocalId,
                Direccion = c.Direccion,
                HoraApertura = _context.Horarios.FindAsync(c.HorarioId).Result.HoraApertura,
                HoraCierre = _context.Horarios.FindAsync(c.HorarioId).Result.HoraCierre,
                Empresa = _context.Empresas.FindAsync(c.EmpresaId).Result.Nombre,
                Distrito = _context.Distritos.FindAsync(c.DistritoId).Result.Nombre,
            });
        }

        // GET: api/Locals/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<LocalViewModel>> Show([FromRoute] int id)
        {
            var local = await _context.Locales.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return Ok(new LocalViewModel
            {
                //LocalId = local.LocalId,
                //Direccion = local.Direccion,
                //EmpresaId = local.EmpresaId,
                //DistritoId = local.DistritoId,
                //HorarioId = local.HorarioId
            });
        }

        // PUT: api/Locals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateLocalViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.LocalId <= 0)//validando que el Localid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Locales.FirstOrDefaultAsync(c => c.LocalId == model.LocalId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el Localid ya esta por defecto
            //cat.Direccion = model.Direccion;
            //cat.EmpresaId = model.EmpresaId;
            //cat.DistritoId = model.DistritoId;
            //cat.HorarioId = model.HorarioId;

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

        // POST: api/Locals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Local>> Create([FromBody]CreateLocalViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Local ca = new Local
            {
            Direccion = model.Direccion,
            EmpresaId = model.EmpresaId,
            DistritoId = model.DistritoId,
            HorarioId = model.HorarioId
        };

            _context.Locales.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Locals/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var category = await _context.Locales.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Locales.Remove(category);
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

        private bool LocalExists(int id)
        {
            return _context.Locales.Any(e => e.LocalId == id);
        }
    }
}
