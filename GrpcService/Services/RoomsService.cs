using Application.Structures.Commands.CreateRoom;
using Application.Structures.Commands.DeleteRoom;
using Application.Structures.Commands.UpdateRoom;
using Application.Structures.Queries.GetAllRooms;
using Application.Structures.Queries.GetRoomById;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class RoomsService : Room.RoomBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomsService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<RoomDTO> CreateRoom(
            CreateRoomRequest request,
            ServerCallContext context)
        {
            var command = new CreateRoomCommand(
                request.Number,
                request.IsProduction,
                request.Description,
                _mapper.Map<Domain.Entities.ConfigurationData.
                Floor>(request.Floor));

            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<RoomDTO>(result));
        }

        public override Task<Empty> DeleteRoom(
            DeleteRequest request,
            ServerCallContext context)
        {
            var command = new DeleteRoomCommand(
                new Guid(request.Id));
            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }

        public override Task<Rooms> GetAllRooms(
            Empty request,
            ServerCallContext context)
        {
            var query = new GetAllRoomsQuery();
            var result = _mediator.Send(query).Result;
            var roomsDTOs = new Rooms();
            roomsDTOs.Items.AddRange(
                result.Select(
                    m => _mapper.Map<RoomDTO>(m)));
            return Task.FromResult(roomsDTOs);
        }

        public override Task<NullableRoomDTO> GetRoom(
            GetRequest request,
            ServerCallContext context)
        {
            var query = new GetRoomByIdQuery(
                new Guid(request.Id));
            var result = _mediator.Send(query).Result;
            if (result is null)
                return Task.FromResult(new NullableRoomDTO()
                { Null = NullValue.NullValue });
            return Task.FromResult(
                new NullableRoomDTO()
                {
                    Room = _mapper.Map<RoomDTO>(result)
                });
        }

        public override Task<Empty> UpdateRoom(
            RoomDTO request,
            ServerCallContext context)
        {
            var command = new UpdateRoomCommand(
                _mapper.Map<Domain.Entities.ConfigurationData
                .Room>(request));

            _mediator.Send(command);
            return Task.FromResult(new Empty());
        }
    }
}
