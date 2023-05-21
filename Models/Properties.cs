using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSV_SQL_Converter.Models

{
    /// <summary>
    /// Classe d'entité representant la table Properties
    /// </summary>
    [Table("Properties")]
    public class Properties : CsvEntity
    {
        /// <summary>
        /// Identifiant de la propriété
        /// </summary>
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// Identifiant du pays lié à la propriété
        /// </summary>
        [Column("CountryId")]
        public string CountryId { get; set; }
        /// <summary>
        /// Identifiant du site
        /// </summary>
        [Column("SiteId")]
        public string SiteId { get; set; }
        /// <summary>
        /// Nom de la propriété
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
       
    }
}
