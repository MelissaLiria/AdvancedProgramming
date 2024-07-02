using Contracts.Structures;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Structures
{
    /// <summary>
    /// Implementación del repositorio IStructureRepository
    /// </summary>
    public class StructureRepository
        : RepositoryBase, IStructureRepository
    {
        public StructureRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddStructure(Structure structure)
        {
            _context.Structures.Add(structure);
        }

        public void UpdateStructure(Structure structure)
        {
            _context.Structures.Update(structure);
        }

        public void DeleteStructure(Structure structure)
        {
            _context.Structures.Remove(structure);
        }

        public T? GetStructureById<T>(Guid id) where T : Structure
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAllStructures<T>() where T : Structure
        {
            return _context.Set<T>().ToList();
        }

       

       
      }
}
