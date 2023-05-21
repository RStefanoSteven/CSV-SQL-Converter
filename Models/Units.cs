using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSV_SQL_Converter.Models
{
    /// <summary>
    /// Classe d'entité representant la table Units
    /// </summary>
    [Table("Units")]
    public class Units : CsvEntity
    {
        /// <summary>
        /// Identifiant d'units/surface
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Identifiant du site associé
        /// </summary>
        [Column("SiteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// Identifiant de la propriété associée
        /// </summary>
        [Column("PropertyId")]
        public string PropertyId { get; set; }

        /// <summary>
        /// Identifiant du pays associée
        /// </summary>
        [Column("CountryId")]
        public string CountryId { get; set; }

        /// <summary>
        /// Surface de la zone
        /// </summary>
        [Column("Area")]
        public string Area { get; set; }
        /// <summary>
        /// Type de zone
        /// </summary>
        [Column("Type")]
        public string Type { get; set; }


    }
}
