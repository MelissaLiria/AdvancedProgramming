using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetAllFloors
{
    public class GetAllFloorsQueryHandler
       : IQueryHandler<GetAllFloorsQuery, IEnumerable<Floor>>
    {
        private readonly IStructureRepository _structureRepository;

        public GetAllFloorsQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }
        public Task<IEnumerable<Floor>> Handle(GetAllFloorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetAllStructures<Floor>());
        }
    }
}
