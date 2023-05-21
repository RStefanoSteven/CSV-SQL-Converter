using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSV_SQL_Converter
{
    /// <summary>
    /// Classe representant un fichier CSV
    /// </summary>
    public class CsvEntity
    {
        [NotMapped]
        public DateTime CreatedAt { get; set; }
        [NotMapped]
        public DateTime UpdatedAt { get; set; }
    }
}
