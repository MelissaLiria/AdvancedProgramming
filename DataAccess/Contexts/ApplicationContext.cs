using Domain.Entities.ConfigurationData;
using Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    internal class ApplicationContext : DbContext
    {
        #region Tables
        /// <summary>
        /// Tabla de Variables
        /// </summary>
        public DbSet<Variable> Variables { get; set; }
        /// <summary>
        /// Tabla de Muestras
        /// </summary>
        public DbSet<Sample> Samples { get; set; }
        /// <summary>
        /// Tabla de Pisos
        /// </summary>
        public DbSet<Floor> Floors { get; set; }
        /// <summary>
        /// Tabla de Habitaciones
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
        /// <summary>
        /// Tabla de Edificios
        /// </summary>
        public DbSet<Building> Buildings { get; set; }
        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones
        /// </summary>
        public ApplicationContext()
        {
        }
        /// <summary>
        /// Inicializa un objeto ApplicationContext
        /// </summary>
        /// <param name="connectionString"></param>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString))
        { 
        }
        /// <summary>
        /// Inicializa un objeto ApplicationContext
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        #region Helpers
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion

    }
}
