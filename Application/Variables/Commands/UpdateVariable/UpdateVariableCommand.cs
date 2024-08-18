using Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Commands.UpdateVariable
{
    public record UpdateVariableCommand(Guid Id) : ICommand;
}
