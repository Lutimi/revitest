using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Categoria;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public CategoriasController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> List()
        {
            var categoryList = await _context.Categorias.ToListAsync();

            return categoryList.Select(c => new CategoriaViewModel
            {
                CategoriaId = c.CategoriaId,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
            });
        }

        // GET: api/Categorias/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CategoriaViewModel>> Show([FromRoute] int id)
        {
            var category = await _context.Categorias.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(new CategoriaViewModel
            {
                CategoriaId = category.CategoriaId,
                Nombre = category.Nombre,
                Descripcion = category.Descripcion,
            });
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.CategoriaId <= 0)//validando que el categoryid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == model.CategoriaId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el categoryid ya esta por defecto
            cat.CategoriaId = model.CategoriaId;
            cat.Nombre = model.Nombre;
            cat.Descripcion = model.Descripcion;

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

        // POST: api/Categorias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Categoria>> Create([FromBody]CreateCategoriaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Categoria ca = new Categoria
            {
            Nombre = model.Nombre,
            Descripcion = model.Descripcion,
        };

            _context.Categorias.Add(ca);//como si escribieras el insert sin ejecutar
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

        // DELETE: api/Categorias/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var category = await _context.Categorias.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(category);
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

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }
    }
}
