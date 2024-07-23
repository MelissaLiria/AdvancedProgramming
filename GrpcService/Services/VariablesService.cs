using Contracts;
using Contracts.Variables;
using EnvironmentalVariablesDAQ.GrpcProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace GrpcService.Services
{
    public class VariablesService : Variable.VariableBase
    {
        private readonly IVariableRepository _variableRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VariablesService(IVariableRepository variableRepository, IUnitOfWork unitOfWork)
        {
            _variableRepository = variableRepository;
            _unitOfWork = unitOfWork;
        } 


        public override Task<VariableDTO> CreateVariable(CreateVariableRequest request, ServerCallContext context)
        {
            return base.CreateVariable(request, context);
        }

        public override Task<Empty> DeleteVariable(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteVariable(request, context);
        }

        public override Task<Variables> GetAllVariables(Empty request, ServerCallContext context)
        {
            return base.GetAllVariables(request, context);
        }

        public override Task<NullableVariableDTO> GetVariable(GetRequest request, ServerCallContext context)
        {
            return base.GetVariable(request, context);
        }

        public override Task<Empty> UpdateVariable(VariableDTO request, ServerCallContext context)
        {
            return base.UpdateVariable(request, context);
        }

    }
}
