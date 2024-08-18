using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.CreateSampleDouble
{
    public record CreateSampleDoubleCommand(
        Guid VariableId,
        double Value) : ICommand<SampleDouble>;
}
