using Application.Abstract;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Commands.CreateBuilding
{
    public record CreateBuildingCommand(
        string Address,
        int Number) : ICommand<Building>;

}
    

