using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSV_SQL_Converter.Models;
using CsvHelper;
using CSV_SQL_Converter.Services;
using CSV_SQL_Converter.Mappers;
using CSV_SQL_Converter.Interfaces;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CSV_SQL_Converter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public CountriesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;   
            this._configuration = configuration;
        }

        //// GET: api/Countries
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Countries>>> GetCountries()
        //{
        //    return await _context.Countries.ToListAsync();
        //}

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countries>> GetCountries(string id)
        {
            var countries = await _context.Countries.FindAsync(id);

            if (countries == null)
            {
                return NotFound();
            }

            return countries;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries(string id, Countries countries)
        {
            if (id != countries.Id)
            {
                return BadRequest();
            }

            _context.Entry(countries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Countries>> PostCountries(Countries countries)
        {
            _context.Countries.Add(countries);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CountriesExists(countries.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCountries", new { id = countries.Id }, countries);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Countries>> DeleteCountries(string id)
        {
            var countries = await _context.Countries.FindAsync(id);
            if (countries == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countries);
            await _context.SaveChangesAsync();

            return countries;
        }

        private bool CountriesExists(string id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
        /// <summary>
        /// Methode permettant d'importer des données sur la BDD à l'aide du CSV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CsvImporter()
        {
            // Chemin de fichier configurable dans le appsettings.json
            string filePath = _configuration["CheminFichierCsv:Country"];

            //List<Countries> Countries = new CsvImporterService<Countries>().ImportData(filePath);
            List<Countries> Countries = new CsvImporterService<Countries>().ImportData(filePath);

            try
            {   
                //On supprime d'abord tout le contenu de la table avant de mettre à jour pour éviter un conflit de données
                _context.Countries.RemoveRange(_context.Countries);
                _context.Countries.AddRange(Countries);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException d)
            {
                throw d;
            }
            catch (Exception e){
                throw e;
            }

        }
    }
}
