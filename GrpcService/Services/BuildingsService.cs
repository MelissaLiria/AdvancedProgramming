using Application.Structures.Commands.CreateBuilding;
using Application.Structures.Commands.DeleteBuilding;
using Application.Structures.Commands.UpdateBuilding;
using Application.Structures.Queries.GetAllBuildings;
using Application.Structures.Queries.GetBuildingById;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class BuildingsService : Building.BuildingBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BuildingsService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<BuildingDTO> CreateBuilding(
            CreateBuildingRequest request,
            ServerCallContext context)
        {
            var command = new CreateBuildingCommand(
                request.Address,
                request.Number);

            var result = _mediator.Send(command).Result;
            return Task
                .FromResult(_mapper.Map<BuildingDTO>(result));
        }

        public override Task<Empty> DeleteBuilding(
            DeleteRequest request,
            ServerCallContext context)
        {
            var command = new DeleteBuildingCommand(
                new Guid(request.Id));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

        public override Task<Buildings> GetAllBuildings(
            Empty request, ServerCallContext context)
        {
            var query = new GetAllBuildingsQuery();

            var result = _mediator.Send(query).Result;
            var buildingsDTOs = new Buildings();
            buildingsDTOs.Items.AddRange(
                result.Select(
                    m => _mapper.Map<BuildingDTO>(m)));
            return Task.FromResult(buildingsDTOs);
        }

        public override Task<NullableBuildingDTO> GetBuilding(
            GetRequest request,
            ServerCallContext context)
        {
            var query = new GetBuildingByIdQuery(
                new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableBuildingDTO()
                { Null = NullValue.NullValue });
            return Task.FromResult(
                new NullableBuildingDTO()
                {
                    Building = _mapper
                .Map<BuildingDTO>(result)
                });
        }

        public override Task<Empty> UpdateBuilding(
            BuildingDTO request,
            ServerCallContext context)
        {
            var command = new UpdateBuildingCommand(
                _mapper.Map<Domain.Entities.ConfigurationData
                .Building>(request));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
    }
}
