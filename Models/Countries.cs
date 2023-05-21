using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSV_SQL_Converter.Models
{
    /// <summary>
    /// Classe d'entité representant la table Countries
    /// </summary>
    [Table("Countries")]
    public class Countries : CsvEntity
    {
        /// <summary>
        /// Identifiant du pays
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Nom du pays
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
