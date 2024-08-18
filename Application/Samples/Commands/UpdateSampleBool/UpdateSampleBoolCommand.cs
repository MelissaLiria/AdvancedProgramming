using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.UpdateSampleBool
{
    public record UpdateSampleBoolCommand(SampleBool SampleBool) : ICommand;
}
