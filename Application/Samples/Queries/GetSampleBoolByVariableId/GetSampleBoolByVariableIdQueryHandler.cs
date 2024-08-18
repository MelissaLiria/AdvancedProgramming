using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleBoolByVariableId
{
    public class GetSampleBoolByVariableIdQueryHandler
        : IQueryHandler<GetSampleBoolByVariableIdQuery, IEnumerable<SampleBool>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleBoolByVariableIdQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleBool>> Handle(GetSampleBoolByVariableIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByVariableId<SampleBool>(request.variableId));
        }
    }
}
