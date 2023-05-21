using CsvHelper.Configuration;
using System.Collections.Generic;

namespace CSV_SQL_Converter.Interfaces
{
    /// <summary>
    /// Interface pour l'importation de données CSV
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICsvImporter<T>
    {
        /// <summary>
        /// Fonction pour importer importer la données CSV vers SQL
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <returns></returns>
        List<T> ImportData(string csvFilePath);

    }
}
