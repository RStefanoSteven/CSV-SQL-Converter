using CSV_SQL_Converter.Models;
using CsvHelper.Configuration;

namespace CSV_SQL_Converter.Mappers
{
    public class SitesMapper : ClassMap<Sites>
    {
        /// <summary>
        /// Lorsque Csv Helper convertira chaque ligne en classe 
        /// Il est necessaire de mapper les noms de colonnes CSV à chaque propriété de classe correspondante
        /// </summary>
        public SitesMapper() { 
            Map(s => s.Id).Name("COD_SITE");
            Map(s => s.Name).Name("LIB_SITE");
            Map(s => s.CountryId).Name("COD_COUNTRY");
            Map(s => s.PostalCode).Name("COD_POSTAL_SITE");
            Map(s => s.Address).Name("LIB_ADDRESS1_SITE");
            Map(s => s.Town).Name("LIB_TOWN_SITE");

        }
    }
}
