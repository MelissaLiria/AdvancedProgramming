using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetAllSampleBools
{
    public class GetAllSampleBoolsQueryHandler
        : IQueryHandler<GetAllSampleBoolsQuery, IEnumerable<SampleBool>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetAllSampleBoolsQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleBool>> Handle(GetAllSampleBoolsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetAllSamples<SampleBool>());
        }
    }
}
