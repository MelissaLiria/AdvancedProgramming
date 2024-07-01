using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Structures
{
    public interface IStructureRepository
    {
        /// <summary>
        /// Añade una estructura al soporte de datos.
        /// </summary>
        /// <param name="structure"></param>
        void AddStructure(Structure structure);

        /// <summary>
        /// Obtienen una estructura del soporte de datos a partir 
        /// de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de estructura a obtener</typeparam>
        /// <param name="id">Identificador de la estructura</param>
        /// <returns>Estructura obtenida del soporte de datos; de 
        /// no existir, <see langword="null"/>.</returns>
        T? GetStructureById<T>(Guid id) where T : Structure;

        /// <summary>
        /// Obtiene todas las estructuras del soporte de datos.
        /// </summary>
        /// <typeparam name="T">Tipo de estructura a obtener</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllStructures<T>() where T : Structure;

        /// <summary>
        /// Actualiza las propiedades de una estructura en el
        /// soporte de datos.
        /// </summary>
        /// <param name="structure">Instancia con la información
        /// a actualizar de la estructura</param>
        void UpdateStructure(Structure structure);

        /// <summary>
        /// Elimina una estructura del soporte de datos.
        /// </summary>
        /// <param name="structure">Estructura a eliminar</param>
        void DeleteStructure(Structure structure);
    }
}
