using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Vehiculo;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoesController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public VehiculoesController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Vehiculoes
        [HttpGet("[action]")]
        public async Task<IEnumerable<VehiculoViewModel>> List()
        {
            var vehiculoList = await _context.Vehiculos.ToListAsync();

            return vehiculoList.Select(c => new VehiculoViewModel
            {
                VehiculoId = c.VehiculoId,
                Placa = c.Placa,
                Color = c.Color,
                FechaFabricacion = c.FechaFabricacion,
                ModeloId = c.ModeloId,
                CategoriaId = c.CategoriaId,
                ConductorId = c.ConductorId
            });
        }

        // GET: api/Vehiculoes/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<VehiculoViewModel>> Show([FromRoute] int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(new VehiculoViewModel
            {
                VehiculoId = vehiculo.VehiculoId,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                FechaFabricacion = vehiculo.FechaFabricacion,
                ModeloId = vehiculo.ModeloId,
                CategoriaId = vehiculo.CategoriaId,
                ConductorId = vehiculo.ConductorId
            });
        }

        // PUT: api/Vehiculoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateVehiculoViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.VehiculoId <= 0)//validando que el Vehiculoid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Vehiculos.FirstOrDefaultAsync(c => c.VehiculoId == model.VehiculoId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el Vehiculoid ya esta por defecto
            cat.Placa = model.Placa;
            cat.Color = model.Color;
            cat.FechaFabricacion = model.FechaFabricacion;
            cat.ModeloId = model.ModeloId;
            cat.CategoriaId = model.CategoriaId;
            cat.ConductorId = model.ConductorId;

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

        // POST: api/Vehiculoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Vehiculo>> Create([FromBody]CreateVehiculoViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Vehiculo ca = new Vehiculo
            {
                Placa = model.Placa,
                Color = model.Color,
                FechaFabricacion = model.FechaFabricacion,
                ModeloId = model.ModeloId,
                CategoriaId = model.CategoriaId,
                ConductorId = model.ConductorId,
            };


            _context.Vehiculos.Add(ca);//como si escribieras el insert sin ejecutar
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




        // DELETE: api/Vehiculoes/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            _context.Vehiculos.Remove(vehiculo);
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

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.VehiculoId == id);
        }
    }
}

