using CSV_SQL_Converter.Models;
using CsvHelper.Configuration;

namespace CSV_SQL_Converter.Mappers
{
    public class UnitsMapper : ClassMap<Units>
    {

        /// <summary>
        /// Lorsque Csv Helper convertira chaque ligne en classe 
        /// Il est necessaire de mapper les noms de colonnes CSV à chaque propriété de classe correspondante
        /// </summary>
        public UnitsMapper() {
            Map(u => u.Id).Name("COD_UNIT");
            Map(u => u.SiteId).Name("COD_SITE");
            Map(u => u.PropertyId).Name("COD_PROPERTY");
            Map(u => u.CountryId).Name("COD_COUNTRY");
            Map(u => u.Type).Name("LIB_TYP_UNIT");
            Map(u => u.Area).Name("SURFACE_UNIT");

        }
    }
}
