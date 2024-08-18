using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetAllSampleDoubles
{
    public class GetAllSampleDoublesQueryHandler
        : IQueryHandler<GetAllSampleDoublesQuery, IEnumerable<SampleDouble>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetAllSampleDoublesQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleDouble>> Handle(GetAllSampleDoublesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetAllSamples<SampleDouble>());
        }
    }
}
