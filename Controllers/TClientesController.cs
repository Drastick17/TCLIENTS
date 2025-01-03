﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TCLIENTS.Data;
using TCLIENTS.Models;

namespace TCLIENTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TClientesController : ControllerBase
    {
        private readonly TCLIENTSContext _context;

        public TClientesController(TCLIENTSContext context)
        {
            _context = context;
        }

        // GET: api/TClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TCliente>>> GetTCliente()
        {
          if (_context.TCliente == null)
          {
              return NotFound();
          }
            return await _context.TCliente.ToListAsync();
        }

        // GET: api/TClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TCliente>> GetTCliente(int id)
        {
          if (_context.TCliente == null)
          {
              return NotFound();
          }
            var tCliente = await _context.TCliente.FindAsync(id);

            if (tCliente == null)
            {
                return NotFound();
            }

            return tCliente;
        }

        // PUT: api/TClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTCliente(int id, TCliente tCliente)
        {
            if (id != tCliente.CLI_Id)
            {
                return BadRequest();
            }

            _context.Entry(tCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TCliente>> PostTCliente(TCliente tCliente)
        {
          if (_context.TCliente == null)
          {
              return Problem("Entity set 'TCLIENTSContext.TCliente'  is null.");
          }
            object[] paramItems = new object[]
            {
                new SqlParameter("@Identificacion", tCliente.CLI_Identificacion),
                new SqlParameter("@NomPrincipal", tCliente.CLI_NombrePrincipal),
                new SqlParameter("@NomSecundario", tCliente.CLI_NombreSecundario),
                new SqlParameter("@ApellidoPaterno", tCliente.CLI_ApellidoPaterno),
                new SqlParameter("@ApellidoMaterno", tCliente.CLI_ApellidoMaterno),
                new SqlParameter("@Direccion", tCliente.CLI_Direccion),
                new SqlParameter("@Telefono", tCliente.CLI_Telefono),
                new SqlParameter("@Correo", tCliente.CLI_Correo),
                new SqlParameter("@FechaNacimieto", tCliente.CLI_FechaNacimiento)
            };

            int respuesta = _context.Database.ExecuteSqlRaw("EXEC [dbo].[SPClienteInsert] @Identificacion,@NomPrincipal,@NomSecundario,@ApellidoPaterno,@ApellidoMaterno,@Direccion,@Telefono,@Correo,@FechaNacimieto ", paramItems);

            return CreatedAtAction("GetTCliente", new { id = tCliente.CLI_Id }, tCliente);
        }

        // DELETE: api/TClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTCliente(int id)
        {
            if (_context.TCliente == null)
            {
                return NotFound();
            }
            var tCliente = await _context.TCliente.FindAsync(id);
            if (tCliente == null)
            {
                return NotFound();
            }

            _context.TCliente.Remove(tCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TClienteExists(int id)
        {
            return (_context.TCliente?.Any(e => e.CLI_Id == id)).GetValueOrDefault();
        }
    }
}
