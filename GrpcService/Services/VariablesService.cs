using Contracts;
using Contracts.Variables;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using System.Reflection.Metadata.Ecma335;
using Application.Variables.Commands.CreateVariable;
using Application.Variables.Queries.GetVariableById;
using GrpcProtos;
using Application.Variables.Commands.DeleteVariable;
using Application.Variables.Queries.GetAllVariables;
using Application.Variables.Commands.UpdateVariable;

namespace GrpcService.Services
{
    public class VariablesService : GrpcProtos.Variable.VariableBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VariablesService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
            Domain.Entities.ConfigurationData.Structure location;

            switch (request.LocationCase)
            {
                case CreateVariableRequest.LocationOneofCase.Building:
                    location = new Domain.Entities.ConfigurationData.Building(
                        new Guid(request.Building.Id),
                        request.Building.Address,
                        request.Building.Number);
                    break;
                case CreateVariableRequest.LocationOneofCase.Floor:
                    location = new Domain.Entities.ConfigurationData.Floor(
                        new Guid(request.Floor.Id),
                        request.Floor.Location,
                        new Domain.Entities.ConfigurationData.Building(
                            new Guid(request.Floor.Building.Id),
                            request.Floor.Building.Address,
                            request.Floor.Building.Number));
                    break;
                case CreateVariableRequest.LocationOneofCase.Room:
                    location = new Domain.Entities.ConfigurationData.Room(
                        new Guid(request.Room.Id),
                        request.Room.Number,
                        request.Room.IsProduction,
                        request.Room.Description,
                        new Domain.Entities.ConfigurationData.Floor(
                            new Guid(request.Floor.Id),
                            request.Room.Floor.Location,
                            new Domain.Entities.ConfigurationData.Building(
                                new Guid(request.Room.Floor.Building.Id),
                                request.Room.Floor.Building.Address,
                                request.Room.Floor.Building.Number)));
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
            
            var command = new CreateVariableCommand(
                location,
                new Domain.ValueObjects.VariableType(
                    request.VariableType.Name,
                    request.VariableType.MeasurementUnit),
                request.Code);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<VariableDTO>(result));
        }

        public override Task<Empty> DeleteVariable(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteVariableCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Variables> GetAllVariables(Empty request, ServerCallContext context)
        {
            var query = new GetAllVariablesQuery();

            var result = _mediator.Send(query).Result;

            var variablesDTOs = new Variables();
            variablesDTOs.Items.AddRange(result.Select(m => _mapper.Map<VariableDTO>(m)));

            return Task.FromResult(variablesDTOs);        
        }

        public override Task<NullableVariableDTO> GetVariable(GetRequest request, ServerCallContext context)
        {
            var query = new GetVariableByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableVariableDTO() { Null = NullValue.NullValue});

            return Task.FromResult(new NullableVariableDTO() { Variable = _mapper.Map<VariableDTO>(result)});

        }

        public override Task<Empty> UpdateVariable(VariableDTO request, ServerCallContext context)
        {
            var command = new UpdateVariableCommand(_mapper.Map<Domain.Entities.ConfigurationData.Variable>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());

        }

    }
}
