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
    public class PdbChainsController : ControllerBase
    {
        private readonly pandosdbContext _context;

        public PdbChainsController(pandosdbContext context)
        {
            _context = context;
        }

        // GET: api/PdbChains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdbChain>>> GetPdbChains()
        {
            return await _context.PdbChains.ToListAsync();
        }

        // GET: api/PdbChains/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdbChain>> GetPdbChain(string id)
        {
            var pdbChain = await _context.PdbChains.FindAsync(id);

            if (pdbChain == null)
            {
                return NotFound();
            }

            return pdbChain;
        }

        // PUT: api/PdbChains/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdbChain(string id, PdbChain pdbChain)
        {
            if (id != pdbChain.PdbId)
            {
                return BadRequest();
            }

            _context.Entry(pdbChain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdbChainExists(id))
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

        // POST: api/PdbChains
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PdbChain>> PostPdbChain(PdbChain pdbChain)
        {
            _context.PdbChains.Add(pdbChain);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PdbChainExists(pdbChain.PdbId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPdbChain", new { id = pdbChain.PdbId }, pdbChain);
        }

        // DELETE: api/PdbChains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdbChain(string id)
        {
            var pdbChain = await _context.PdbChains.FindAsync(id);
            if (pdbChain == null)
            {
                return NotFound();
            }

            _context.PdbChains.Remove(pdbChain);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdbChainExists(string id)
        {
            return _context.PdbChains.Any(e => e.PdbId == id);
        }
    }
}
