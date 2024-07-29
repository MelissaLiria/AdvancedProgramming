using Application.Abstract;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.DeleteRoom
{
    public record DeleteRoomCommand(
        Guid Id) : ICommand;
}
