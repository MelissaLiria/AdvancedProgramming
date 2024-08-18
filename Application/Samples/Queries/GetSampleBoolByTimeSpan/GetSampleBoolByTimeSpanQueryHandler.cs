using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleBoolByTimeSpan
{
    public class GetSampleBoolByTimeSpanQueryHandler
        : IQueryHandler<GetSampleBoolByTimeSpanQuery, IEnumerable<SampleBool>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleBoolByTimeSpanQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleBool>> Handle(GetSampleBoolByTimeSpanQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByTimeSpan<SampleBool>(request.StartTime, request.EndTime));
        }
    }
}
