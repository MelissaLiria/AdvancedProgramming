using Application.Samples.Commands.CreateSampleInt;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class SampleIntsService : SampleInt.SampleIntBase
    {

        private readonly IMediator _mediator;

        public SampleIntsService(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public override Task<SampleIntDTO> CreateSampleInt(CreateSampleIntRequest request, ServerCallContext context)
        {
            var command = new CreateSampleIntCommand(
                new Guid(request.VariableId),
                request.Value);

            var result = _mediator.Send(command).Result;

        }

        public override Task<Empty> DeleteSampleInt(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSampleInt(request, context);
        }

        public override Task<SampleInts> GetAllSampleInts(Empty request, ServerCallContext context)
        {
            return base.GetAllSampleInts(request, context);
        }
        public override Task<SampleInts> GetSampleIntByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            return base.GetSampleIntByTimeSpan(request, context);
        }

        public override Task<NullableSampleIntDTO> GetSampleIntByVariableId(GetRequest request, ServerCallContext context)
        {
            return base.GetSampleIntByVariableId(request, context);
        }

        public override Task<Empty> UpdateSampleInt(SampleIntDTO request, ServerCallContext context)
        {
            return base.UpdateSampleInt(request, context);
        }

    }
}
