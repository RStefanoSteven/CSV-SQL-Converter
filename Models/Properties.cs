namespace CSV_SQL_Converter.Models
{
    public class Properties
    {
        /// <summary>
        /// Identifiant de la propriété
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Identifiant du pays lié à la propriété
        /// </summary>
        public string CountryId { get; set; }
        /// <summary>
        /// Identifiant du site
        /// </summary>
        public string SiteId { get; set; }
        /// <summary>
        /// Nom de la propriété
        /// </summary>
        public string Name { get; set; }
       
    }
}
