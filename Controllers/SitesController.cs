using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSV_SQL_Converter.Models;
using CSV_SQL_Converter.Services;
using Microsoft.Extensions.Configuration;

namespace CSV_SQL_Converter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;


        public SitesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;

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

        /// <summary>
        /// Methode permettant d'importer des données sur la BDD à l'aide du CSV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CsvImporter()
        {
            string filePath = _configuration["CheminFichierCsv:Site"];

            List<Sites> sites = new CsvImporterService<Sites>().ImportData(filePath);

            try
            {
                //On supprime d'abord tout le contenu de la table avant de mettre à jour pour éviter un conflit de données
                _context.Sites.RemoveRange(_context.Sites);
                _context.Sites.AddRange(sites);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException d)
            {
                throw d;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
