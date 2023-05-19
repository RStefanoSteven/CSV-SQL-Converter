using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSV_SQL_Converter.Models
{
    /// <summary>
    /// Classe d'entité représentant la table Sites
    /// </summary>
    [Table("Sites")]
    public class Sites
    {
        /// <summary>
        /// Identifiant du site
        /// </summary>
        [Key]
        public string Id { get; set; }


        /// <summary>
        /// Identifiant du pays associé
        /// </summary>
        [Column("CountryId")]
        public string CountryId { get; set; }

        /// <summary>
        /// Address du site
        /// </summary>
        [Column("Address1")]
        public string Address { get; set; }

        /// <summary>
        /// Nom du Site
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Code postal du site
        /// </summary>
        [Column("PostalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Ville du site
        /// </summary>
        [Column("Town")]
        public string Town { get; set; }

    }
}
