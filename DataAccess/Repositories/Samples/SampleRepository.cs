using Contracts.Samples;
using DataAccess.Contexts;
using DataAccess.Repositories.Common;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Samples
{
    /// <summary>
    /// Implementación del repositorio ISampleRepository
    /// </summary>
    public class SampleRepository
        : RepositoryBase, ISampleRepository
    {
        public void AddSample(Sample sample)
        {
            _context.Samples.Add(sample);
        }

        public void DeleteSample(Sample sample)
        {
            _context.Samples.Remove(sample);
        }

        public IEnumerable<T> GetAllSamples<T>() where T : Sample
        {
            return _context.Set<T>().ToList();
        }

        public T? GetSampleById<T>(Guid id) where T : Sample
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void UpdateSample(Sample sample)
        {
            _context.Samples.Update(sample);
        }

        public SampleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
