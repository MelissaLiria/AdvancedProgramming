using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetBuildingById
{
    public class GetBuildingByIdQueryHandler 
        : IQueryHandler<GetBuildingByIdQuery, Building?>
    {
        private readonly IStructureRepository _structureRepository;

        public GetBuildingByIdQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Building?> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetStructureById<Building>(request.Id));
        }
    }
}
