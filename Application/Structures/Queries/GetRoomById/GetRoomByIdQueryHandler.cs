using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetRoomById
{
    public class GetRoomByIdQueryHandler
       : IQueryHandler<GetRoomByIdQuery, Room?>
    {
        private readonly IStructureRepository _structureRepository;

        public GetRoomByIdQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }

        public Task<Room?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetStructureById<Room>(request.Id));
        }
    }
}
