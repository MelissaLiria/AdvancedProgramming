using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Queries.GetAverageOfSampleInts
{
    public class GetAverageOfSampleIntsQueryHandler : IQueryHandler<GetAverageOfSampleIntsQuery, Double>
    {
        public GetAverageOfSampleIntsQueryHandler()
        {
        }

        public Task<double> Handle(GetAverageOfSampleIntsQuery request, CancellationToken cancellationToken)
        {
            double sum = 0;

            foreach (SampleInt sampleInt in request.SampleInts)
            {
                double value = Convert.ToDouble(sampleInt.Value);
                sum += value;
            }
            double average = sum / (double)request.SampleInts.Count();
            return Task.FromResult(average);
        }
    }
}
