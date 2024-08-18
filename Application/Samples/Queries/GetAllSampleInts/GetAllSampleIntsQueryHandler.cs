using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetAllSampleInts
{
    public class GetAllSampleIntsQueryHandler
        : IQueryHandler<GetAllSampleIntsQuery, IEnumerable<SampleInt>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetAllSampleIntsQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleInt>> Handle(GetAllSampleIntsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetAllSamples<SampleInt>());
        }
    }
}
