using Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.DeleteSampleDouble
{
    public record DeleteSampleDoubleCommand(Guid VariableId, DateTime DateTime) : ICommand;
}
