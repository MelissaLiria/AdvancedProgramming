using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetSampleDoubleByTimeSpan
{
    public record GetSampleDoubleByTimeSpanQuery(DateTime StartTime, DateTime EndTime) : IQuery<IEnumerable<SampleDouble>>;
}
