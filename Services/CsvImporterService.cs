using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CSV_SQL_Converter.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Linq;
using CSV_SQL_Converter.Models;
using CSV_SQL_Converter.Mappers;
using System;

namespace CSV_SQL_Converter.Services
{

    public class CsvImporterService<T> : ICsvImporter<T>
    {
        //// Propriété permettant d'exploiter les classes de mappage de la classe T
        private Dictionary<Type, object> classMaps;

        //Constructeur demandant une classe de mappage de l'entité de type T
        public CsvImporterService()
        {
            // Initialiser le dictionnaire des ClassMap personnalisées
            classMaps = new Dictionary<Type, object>
        {
            { typeof(Countries), new CountriesMapper() },
            { typeof(PropertiesMapper), new PropertiesMapper() },
            { typeof(Sites), new SitesMapper() },
            { typeof(Units), new UnitsMapper() },

        };
        }

        /// <summary>
        /// Fonction générique qui permet d'importer les fichiers CSV 
        /// Requiert une existence de mappage pour la classe de type T
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <returns></returns>
        public List<T> ImportData(string csvFilePath)
        {
            // Configuration du lecteur CSV
            CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.Delimiter = ";";
            configuration.HasHeaderRecord = true;

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                using (CsvReader csv = new CsvReader(reader, configuration))
                {
                    // Recherche de la ClassMap correspondante en fonction du type de classe T
                    // A définir dans les Mappers
                    // Récupérer le ClassMap correspondant au type de classe T
                    ClassMap classMap = (ClassMap)classMaps[typeof(T)];

                    csv.Context.RegisterClassMap(classMap);
                    return csv.GetRecords<T>().ToList();
                }
            }
        }

    }
}
