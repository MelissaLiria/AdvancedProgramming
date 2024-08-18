using Application.Abstract;
using Domain.Entities.ConfigurationData;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Variables.Commands.CreateVariable
{
    public record CreateVariableCommand(
        Structure Location,
        VariableType Variabletype,
        string Code) : ICommand<Variable>;
}
