using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleIntByTimeSpan
{
    public class GetSampleIntByTimeSpanQueryHandler
        : IQueryHandler<GetSampleIntByTimeSpanQuery, IEnumerable<SampleInt>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleIntByTimeSpanQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleInt>> Handle(GetSampleIntByTimeSpanQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByTimeSpan<SampleInt>(request.StartTime, request.EndTime));
        }
    }
}
