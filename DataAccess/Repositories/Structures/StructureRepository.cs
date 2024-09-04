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
            if (structure is Building)
            {
                var floorElements = GetAllStructures<Floor>().ToList();
                foreach (Floor floor in floorElements)
                {
                    if(floor.BuildingId == structure.Id)
                        DeleteStructure(floor);
                }
            }
            else if (structure is Floor)
            {
                var roomElements = GetAllStructures<Room>().ToList();
                foreach (Room room in roomElements)
                {
                    if (room.FloorId == structure.Id)
                        DeleteStructure(room);
                }
            }
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
