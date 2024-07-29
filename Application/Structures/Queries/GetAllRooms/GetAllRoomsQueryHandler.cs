using Application.Abstract;
using Contracts.Structures;
using Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Structures.Queries.GetAllRooms
{
    public class GetAllRoomsQueryHandler
        : IQueryHandler<GetAllRoomsQuery, IEnumerable<Room>>
    {
        private readonly IStructureRepository _structureRepository;

        public GetAllRoomsQueryHandler(
            IStructureRepository structureRepository)
        {
            _structureRepository = structureRepository;
        }
        public Task<IEnumerable<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_structureRepository.GetAllStructures<Room>());
        }
    }
}
