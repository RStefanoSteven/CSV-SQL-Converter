using CSV_SQL_Converter.Models;
using CsvHelper.Configuration;

namespace CSV_SQL_Converter.Mappers

{
    public class CountriesMapper : ClassMap<Countries>
    {
        /// <summary>
        /// Lorsque Csv Helper convertira chaque ligne en classe 
        /// Il est necessaire de mapper les noms de colonnes CSV à chaque propriété de classe correspondante
        /// </summary>
        public CountriesMapper() { 
            Map(c => c.Id).Name("COD_COUNTRY");
            Map(c => c.Name).Name("LIB_COUNTRY");

        }
    }
}
