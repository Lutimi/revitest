using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Empresa;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public EmpresasController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet("[action]")]
        public async Task<IEnumerable<EmpresaViewModel>> List()
        {
            var empresaList = await _context.Empresas.ToListAsync();

            return empresaList.Select(c => new EmpresaViewModel
            {
              EmpresaId=c.EmpresaId,
              Nombre=c.Nombre,
              Correo=c.Correo,
              Ruc=c.Ruc,
              Telefono=c.Telefono
            });
        }

        // GET: api/Empresas/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<EmpresaViewModel>> Show([FromRoute] int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(new EmpresaViewModel
            {
                EmpresaId = empresa.EmpresaId,
                Nombre = empresa.Nombre,
                Correo = empresa.Correo,
                Ruc = empresa.Ruc,
                Telefono = empresa.Telefono
            });
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEmpresaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.EmpresaId <= 0)//validando que el Empresaid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Empresas.FirstOrDefaultAsync(c => c.EmpresaId == model.EmpresaId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el Empresaid ya esta por defecto
            cat.Nombre = model.Nombre;
            cat.Correo = model.Correo;
            cat.Ruc = model.Ruc;
            cat.Telefono = model.Telefono;

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

        // POST: api/Empresas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Empresa>> Create([FromBody]CreateEmpresaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Empresa ca = new Empresa
            {
            Nombre = model.Nombre,
            Correo = model.Correo,
            Ruc = model.Ruc,
            Telefono = model.Telefono
        };

            _context.Empresas.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Empresas/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var category = await _context.Empresas.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Empresas.Remove(category);
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

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.EmpresaId == id);
        }
    }
}
