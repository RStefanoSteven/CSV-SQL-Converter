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
    public class PropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public PropertiesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Properties>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Properties>> GetProperties(string id)
        {
            var properties = await _context.Properties.FindAsync(id);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperties(string id, Properties properties)
        {
            if (id != properties.Id)
            {
                return BadRequest();
            }

            _context.Entry(properties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertiesExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Properties>> PostProperties(Properties properties)
        {
            _context.Properties.Add(properties);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropertiesExists(properties.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProperties", new { id = properties.Id }, properties);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Properties>> DeleteProperties(string id)
        {
            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();

            return properties;
        }

        private bool PropertiesExists(string id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }

        /// <summary>
        /// Methode permettant d'importer des données sur la BDD à l'aide du CSV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CsvImporter()
        {
            // Chemin de fichier configurable dans le appsettings.json
            string filePath = _configuration["CheminFichierCsv:Properties"];

            List<Properties> properties = new CsvImporterService<Properties>().ImportData(filePath);

            try
            {
                //On supprime d'abord tout le contenu de la table avant de mettre à jour pour éviter un conflit de données
                _context.Properties.RemoveRange(_context.Properties);
                _context.Properties.AddRange(properties);
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
