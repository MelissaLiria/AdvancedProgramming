using Application.Abstract;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleDoubleByVariableId
{
    public class GetSampleDoubleByVariableIdQueryHandler
        : IQueryHandler<GetSampleDoubleByVariableIdQuery, IEnumerable<SampleDouble>>
    {
        private readonly ISampleRepository _sampleRepository;

        public GetSampleDoubleByVariableIdQueryHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task<IEnumerable<SampleDouble>> Handle(GetSampleDoubleByVariableIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sampleRepository.GetSamplesByVariableId<SampleDouble>(request.variableId));
        }
    }
}
