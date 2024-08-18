using Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.DeleteSampleInt
{
    public record DeleteSampleIntCommand(Guid VariableId, DateTime DateTime) : ICommand;
}
