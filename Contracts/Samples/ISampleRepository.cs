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
        /// Obtiene las muestras en un intervalo de tiempo.
        /// </summary>
        /// <typeparam name="T">Tipo de muestras a obtener</typeparam>
        /// <param name="start">Extremo inferior del rango de tiempo</param>
        /// <param name="end">Extremo superior del rango de tiempo</param>
        /// <returns></returns>
        IEnumerable<T> GetSamplesByTimeSpan<T>(DateTime start, DateTime end) where T : Sample;

        /// <summary>
        /// Obtiene las muestras de una variable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableId"></param>
        /// <returns></returns>
        IEnumerable<T> GetSamplesByVariableId<T>(Guid variableId) where T : Sample;

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
