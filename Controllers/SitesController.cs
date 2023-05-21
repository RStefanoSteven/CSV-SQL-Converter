using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSV_SQL_Converter.Models;

namespace CSV_SQL_Converter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SitesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sites>>> GetSites()
        {
            return await _context.Sites.ToListAsync();
        }

        // GET: api/Sites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sites>> GetSites(string id)
        {
            var sites = await _context.Sites.FindAsync(id);

            if (sites == null)
            {
                return NotFound();
            }

            return sites;
        }

        // PUT: api/Sites/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSites(string id, Sites sites)
        {
            if (id != sites.Id)
            {
                return BadRequest();
            }

            _context.Entry(sites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitesExists(id))
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

        // POST: api/Sites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sites>> PostSites(Sites sites)
        {
            _context.Sites.Add(sites);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SitesExists(sites.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSites", new { id = sites.Id }, sites);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sites>> DeleteSites(string id)
        {
            var sites = await _context.Sites.FindAsync(id);
            if (sites == null)
            {
                return NotFound();
            }

            _context.Sites.Remove(sites);
            await _context.SaveChangesAsync();

            return sites;
        }

        private bool SitesExists(string id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
