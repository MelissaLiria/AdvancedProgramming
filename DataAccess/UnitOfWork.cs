using Contracts;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Implementación de <see cref="IUnitOfWork"/>.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Define el context como campo interno para 
        /// poder utilizarlo para salvar los cambios.
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Verifica si se establece la conexion con la BD, 
        /// si no es posible, se genera la BD.
        /// </summary>
        /// <param name="context">Contexto de la BD</param>
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }

        /// <summary>
        /// Guarda los cambios realizados.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
