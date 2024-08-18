using Application.Abstract;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.CreateRoom
{
    public record CreateRoomCommand(
          int Number,
          bool IsProduction,
          string Description,
          Floor Floor) : ICommand<Room>;
}
