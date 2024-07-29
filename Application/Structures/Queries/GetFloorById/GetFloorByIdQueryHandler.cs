using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetFloorById
{
    public class GetFloorByIdQueryHandler
        : IQueryHandler<GetFloorByIdQuery, Floor?>
    {
        private readonly IStructureRepository _structureRepository;

        public GetFloorByIdQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Floor?> Handle(GetFloorByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetStructureById<Floor>(request.Id));
        }
    }
}
