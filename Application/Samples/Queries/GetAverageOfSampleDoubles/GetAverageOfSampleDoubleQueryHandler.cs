using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetAverageOfSampleDoubles
{
    public class GetAverageOfSampleDoubleQueryHandler : IQueryHandler<GetAverageOfSampleDoublesQuery, double>
    {
        public GetAverageOfSampleDoubleQueryHandler()
        {
        }

        public Task<double> Handle(GetAverageOfSampleDoublesQuery request, CancellationToken cancellationToken)
        {
            double sum = 0;

            foreach (SampleDouble sampleDouble in request.SampleDoubles)
            {
                double value = sampleDouble.Value;
                sum += value;
            }
            double average = sum / (double)request.SampleDoubles.Count();
            return Task.FromResult(average);
        }
    }
}
