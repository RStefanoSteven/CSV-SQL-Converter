using CSV_SQL_Converter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CSV_SQL_Converter.Data
{
    /// <summary>
    /// Classe représentant le contexte de base de données et définit les DbSet correspondants aux entités.
    /// </summary>
    public class AppDbContext : DbContext
    {
        // Collection permettant d'accéder aux objets dans la base de données
        public DbSet<Sites> Sites { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Properties> Properties { get; set; }

        /// <summary>
        /// Fonction pour configurer la connection à la base de données
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
