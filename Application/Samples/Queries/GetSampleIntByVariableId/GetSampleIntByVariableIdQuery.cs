using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleIntByVariableId
{
    public record GetSampleIntByVariableIdQuery(Guid variableId) : IQuery<IEnumerable<SampleInt>>;
}
