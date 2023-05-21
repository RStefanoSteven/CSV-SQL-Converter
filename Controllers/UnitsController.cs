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
    public class UnitsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;


        public UnitsController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            this._configuration = configuration;

        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Units>>> GetUnits()
        {
            return await _context.Units.ToListAsync();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Units>> GetUnits(string id)
        {
            var units = await _context.Units.FindAsync(id);

            if (units == null)
            {
                return NotFound();
            }

            return units;
        }

        /// <summary>
        /// Fonction pour récupérer les boutiques en fonction du pays, de l’emplacement et de la zone.
        /// </summary>
        /// <param name="code_pays"></param>
        /// <param name="code_emplacement"></param>
        /// <param name="code_zone"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<List<Units>> GetUnits(string code_pays, string code_emplacement, string code_zone)
        {
            List<Units> units = await _context.Units.Where(u => u.CountryId == code_pays && u.SiteId == code_emplacement && u.PropertyId == code_zone ).ToListAsync();         

            return units;
        }

        // PUT: api/Units/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnits(string id, Units units)
        {
            if (id != units.Id)
            {
                return BadRequest();
            }

            _context.Entry(units).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsExists(id))
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

        // POST: api/Units
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Units>> PostUnits(Units units)
        {
            _context.Units.Add(units);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnitsExists(units.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnits", new { id = units.Id }, units);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Units>> DeleteUnits(string id)
        {
            var units = await _context.Units.FindAsync(id);
            if (units == null)
            {
                return NotFound();
            }

            _context.Units.Remove(units);
            await _context.SaveChangesAsync();

            return units;
        }

        private bool UnitsExists(string id)
        {
            return _context.Units.Any(e => e.Id == id);
        }

        /// <summary>
        /// Methode permettant d'importer des données sur la BDD à l'aide du CSV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CsvImporter()
        {
            // Chemin de fichier configurable dans le appsettings.json
            string filePath = _configuration["CheminFichierCsv:Shop"];

            List<Units> units = new CsvImporterService<Units>().ImportData(filePath);

            try
            {
                //On supprime d'abord tout le contenu de la table avant de mettre à jour pour éviter un conflit de données
                _context.Units.RemoveRange(_context.Units);
                _context.Units.AddRange(units);
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
