namespace CSV_SQL_Converter.Models
{
    public class Sites
    {
        /// <summary>
        /// Identifiant du site
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifiant du pays associé
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// Address du site
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Nom du Site
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Code postal du site
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Ville du site
        /// </summary>
        public string Town { get; set; }

    }
}
