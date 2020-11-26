using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Departamento;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public DepartamentosController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos/List
        [HttpGet("[action]")]
        public async Task<IEnumerable<DepartamentoViewModel>> List()
        {
            var departamentoList = await _context.Departamento.ToListAsync();

            return departamentoList.Select(d => new DepartamentoViewModel
            {
                DepartamentoId = d.DepartamentoId,
                Nombre = d.Nombre 
            });
        }

        // GET: api/Departamentos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoViewModel>> Show([FromRoute]int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return Ok(new DepartamentoViewModel   {
              DepartamentoId=departamento.DepartamentoId,
              Nombre=departamento.Nombre
            });
        }

        // PUT: api/Departamentos/Update/1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{action}/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDepartamentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Error 404
                return BadRequest(ModelState);
            }

            if (model.DepartamentoId <= 0)
            {
                return BadRequest();
            }
            // FirstOrDefaultAsync encuentra la primera coincidencia que encuentre
            // await porque es asyncrono
            var cat = await _context.Departamento.FirstOrDefaultAsync(c => c.DepartamentoId == model.DepartamentoId);

            if (cat == null)
            {
                return NotFound();
            }

            // el id lo asigna por defecto
            cat.Nombre = model.Nombre;

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

        // POST: api/Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Departamento>> Create([FromBody] CreateDepartamentoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Departamento departamento = new Departamento
            {
                Nombre = model.Nombre,
            };

            _context.Departamento.Add(departamento);

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

        // DELETE: api/Departamentos/1
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            _context.Departamento.Remove(departamento);
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

        private bool DepartamentoExists(int id)
        {
            return _context.Departamento.Any(e => e.DepartamentoId == id);
        }
    }
}
