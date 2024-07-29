using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetAllBuildings
{
    public class GetAllBuildingsQueryHandler
        : IQueryHandler<GetAllBuildingsQuery, IEnumerable<Building>>
    {
        private readonly IStructureRepository _structureRepository;

        public GetAllBuildingsQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }
        public Task<IEnumerable<Building>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetAllStructures<Building>());
        }
    }
}
