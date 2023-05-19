using CSV_SQL_Converter.Models;
using CsvHelper.Configuration;

namespace CSV_SQL_Converter.Mappers
{
    public class PropertiesMapper : ClassMap<Properties>
    {
        /// <summary>
        /// Lorsque Csv Helper convertira chaque ligne en classe 
        /// Il est necessaire de mapper les noms de colonnes CSV à chaque propriété de classe correspondante
        /// </summary>
        public PropertiesMapper() { 
            Map(p => p.Id).Name("COD_PROPERTY");
            Map(p => p.SiteId).Name("COD_SITE");
            Map(p => p.CountryId).Name("COD_COUNTRY");
            Map(p => p.Name).Name("LIB_PROPERTY");

        }
    }
}
