#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdbsController : ControllerBase
    {
        private readonly proteindomainannotationsContext _context;

        public PdbsController(proteindomainannotationsContext context)
        {
            _context = context;
        }

        // GET: api/Pdbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pdb>>> GetPdbs()
        {
            return await _context.Pdbs.ToListAsync();
        }

        // GET: api/Pdbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pdb>> GetPdb(string id)
        {
            var pdb = await _context.Pdbs.FindAsync(id);

            if (pdb == null)
            {
                return NotFound();
            }

            return pdb;
        }

        // PUT: api/Pdbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdb(string id, Pdb pdb)
        {
            if (id != pdb.PdbId)
            {
                return BadRequest();
            }

            _context.Entry(pdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdbExists(id))
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

        // POST: api/Pdbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pdb>> PostPdb(Pdb pdb)
        {
            _context.Pdbs.Add(pdb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PdbExists(pdb.PdbId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPdb", new { id = pdb.PdbId }, pdb);
        }

        // DELETE: api/Pdbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdb(string id)
        {
            var pdb = await _context.Pdbs.FindAsync(id);
            if (pdb == null)
            {
                return NotFound();
            }

            _context.Pdbs.Remove(pdb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdbExists(string id)
        {
            return _context.Pdbs.Any(e => e.PdbId == id);
        }
    }
}
