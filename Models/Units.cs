namespace CSV_SQL_Converter.Models
{
    public class Units
    {
        /// <summary>
        /// Identifiant d'units/surface
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifiant du site associé
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Identifiant de la propriété associée
        /// </summary>
        public string PropertyId { get; set; }

        /// <summary>
        /// Identifiant du pays associée
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Surface de la zone
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Type de zone
        /// </summary>
        public string Type { get; set; }


    }
}
