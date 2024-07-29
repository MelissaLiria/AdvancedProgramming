using Application.Structures.Commands.CreateFloor;
using Application.Structures.Commands.DeleteFloor;
using Application.Structures.Commands.UpdateFloor;
using Application.Structures.Queries.GetAllFloors;
using Application.Structures.Queries.GetFloorById;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class FloorsService : Floor.FloorBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FloorsService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<FloorDTO> CreateFloor(
            CreateFloorRequest request,
            ServerCallContext context)
        {
            var command = new CreateFloorCommand(
                request.Location,
                _mapper.Map<Domain.Entities.ConfigurationData.
                Building>(request.Building));

            var result = _mediator.Send(command).Result;
            return Task
                .FromResult(_mapper.Map<FloorDTO>(result));
        }

        public override Task<Empty> DeleteFloor(
            DeleteRequest request,
            ServerCallContext context)
        {
            var command = new DeleteFloorCommand(
                new Guid(request.Id));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

        public override Task<Floors> GetAllFloors(
            Empty request,
            ServerCallContext context)
        {
            var query = new GetAllFloorsQuery();

            var result = _mediator.Send(query).Result;
            var floorsDTOs = new Floors();
            floorsDTOs.Items.AddRange(
                result.Select(
                    m => _mapper.Map<FloorDTO>(m)));
            return Task.FromResult(floorsDTOs);
        }

        public override Task<NullableFloorDTO> GetFloor(
            GetRequest request,
            ServerCallContext context)
        {
            var query = new GetFloorByIdQuery(
               new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableFloorDTO()
                { Null = NullValue.NullValue });
            return Task.FromResult(
                new NullableFloorDTO()
                {
                    Floor = _mapper.Map<FloorDTO>(result)
                });

        }
        public override Task<Empty> UpdateFloor(
            FloorDTO request,
            ServerCallContext context)
        {
            var command = new UpdateFloorCommand(
                _mapper.Map<Domain.Entities.ConfigurationData
                .Floor>(request));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

    }

}