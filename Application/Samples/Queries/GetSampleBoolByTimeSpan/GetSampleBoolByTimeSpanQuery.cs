using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleBoolByTimeSpan
{
    public record GetSampleBoolByTimeSpanQuery(DateTime StartTime, DateTime EndTime) : IQuery<IEnumerable<SampleBool>>;
}
