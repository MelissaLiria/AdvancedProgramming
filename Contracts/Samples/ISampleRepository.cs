using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Samples
{
    public interface ISampleRepository
    {
        /// <summary>
        /// Añade una muestra al soporte de datos.
        /// </summary>
        /// <param name="sample"></param>
        void AddSample(Sample sample);

        /// <summary>
        /// Obtienen una muestra del soporte de datos a partir
        /// de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de muestra a obtener</typeparam>
        /// <param name="id">Identificador de la muestra</param>
        /// <returns>Muestra obtenida del soporte de datos; de no
        /// existir, <see langword="null"/>.</returns>
        T? GetSampleById<T>(Guid id) where T : Sample;

        /// <summary>
        /// Obtiene todas las muestras del soporte de datos.
        /// </summary>
        /// <typeparam name="T">Tipo de muestra a obtener</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllSamples<T>() where T : Sample;

        /// <summary>
        /// Actualiza las propiedades de una muestra en el 
        /// soporte de datos.
        /// </summary>
        /// <param name="sample">Instancia con la información
        /// a actualizar de la muestra</param>
        void UpdateSample(Sample sample);

        /// <summary>
        /// Elimina una muestra del soporte de datos.
        /// </summary>
        /// <param name="sample">Muestra a eliminar</param>
        void DeleteSample(Sample sample);
    }
}
