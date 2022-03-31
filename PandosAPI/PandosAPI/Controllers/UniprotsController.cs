#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PandosAPI.Models;

namespace PandosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniprotsController : ControllerBase
    {
        private readonly proteindomainannotationsContext _context;

        public UniprotsController(proteindomainannotationsContext context)
        {
            _context = context;
        }


        // GET: api/Uniprots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uniprot>>> GetUniprots()
        {
            return await _context.Uniprots.ToListAsync();
        }

        // GET: api/Uniprots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uniprot>> GetUniprot(string id)
        {
            var uniprot = await _context.Uniprots.FindAsync(id);

            if (uniprot == null)
            {
                return NotFound();
            }

            return uniprot;
        }

        // PUT: api/Uniprots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniprot(string id, Uniprot uniprot)
        {
            if (id != uniprot.UniprotId)
            {
                return BadRequest();
            }

            _context.Entry(uniprot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniprotExists(id))
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

        // POST: api/Uniprots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uniprot>> PostUniprot(Uniprot uniprot)
        {
            _context.Uniprots.Add(uniprot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UniprotExists(uniprot.UniprotId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUniprot", new { id = uniprot.UniprotId }, uniprot);
        }

        // DELETE: api/Uniprots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniprot(string id)
        {
            var uniprot = await _context.Uniprots.FindAsync(id);
            if (uniprot == null)
            {
                return NotFound();
            }

            _context.Uniprots.Remove(uniprot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniprotExists(string id)
        {
            return _context.Uniprots.Any(e => e.UniprotId == id);
        }
    }
}
