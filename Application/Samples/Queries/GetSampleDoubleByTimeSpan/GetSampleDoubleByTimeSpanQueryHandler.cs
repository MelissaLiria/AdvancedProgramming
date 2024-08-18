using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleDoubleByTimeSpan
{
    public class GetSampleDoubleByTimeSpanQueryHandler
        : IQueryHandler<GetSampleDoubleByTimeSpanQuery, IEnumerable<SampleDouble>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleDoubleByTimeSpanQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleDouble>> Handle(GetSampleDoubleByTimeSpanQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByTimeSpan<SampleDouble>(request.StartTime, request.EndTime));
        }
    }
}
