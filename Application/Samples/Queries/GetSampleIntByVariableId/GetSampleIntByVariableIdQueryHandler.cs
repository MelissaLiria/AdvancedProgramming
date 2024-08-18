using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleIntByVariableId
{
    public class GetSampleIntByVariableIdQueryHandler
        : IQueryHandler<GetSampleIntByVariableIdQuery, IEnumerable<SampleInt>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleIntByVariableIdQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleInt>> Handle(GetSampleIntByVariableIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByVariableId<SampleInt>(request.variableId));
        }
    }
}
