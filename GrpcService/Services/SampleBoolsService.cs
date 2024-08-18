using Application.Samples.Commands.CreateSampleBool;
using Application.Samples.Commands.DeleteSampleBool;
using Application.Samples.Commands.UpdateSampleBool;
using Application.Samples.Queries.GetAllSampleBools;
using Application.Samples.Queries.GetSampleBoolByTimeSpan;
using Application.Samples.Queries.GetSampleBoolByVariableId;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class SampleBoolsService : SampleBool.SampleBoolBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SampleBoolsService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SampleBoolDTO> CreateSampleBool(CreateSampleBoolRequest request, ServerCallContext context)
        {
            var command = new CreateSampleBoolCommand(
                new Guid(request.VariableId),
                request.Value);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SampleBoolDTO>(result));
        }

        public override Task<Empty> DeleteSampleBool(DeleteSampleRequest request, ServerCallContext context)
        {
            var command = new DeleteSampleBoolCommand(new Guid(request.VariableId), DateTime.Parse(request.DateTime));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<SampleBools> GetAllSampleBools(Empty request, ServerCallContext context)
        {
            var query = new GetAllSampleBoolsQuery();

            var result = _mediator.Send(query).Result;

            var sampleBoolDTOs = new SampleBools();
            sampleBoolDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleBoolDTO>(m)));

            return Task.FromResult(sampleBoolDTOs);
        }

        public override Task<SampleBools> GetSampleBoolByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            var query = new GetSampleBoolByTimeSpanQuery(DateTime.Parse(request.StartTime), DateTime.Parse(request.EndTime));

            var result = _mediator.Send(query).Result;

            var sampleBoolDTOs = new SampleBools();
            sampleBoolDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleBoolDTO>(m)));

            return Task.FromResult(sampleBoolDTOs);
        }

        public override Task<SampleBools> GetSampleBoolByVariableId(GetRequest request, ServerCallContext context)
        {
            var query = new GetSampleBoolByVariableIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            var sampleBoolDTOs = new SampleBools();
            sampleBoolDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleBoolDTO>(m)));

            return Task.FromResult(sampleBoolDTOs);
        }

        public override Task<Empty> UpdateSampleBool(SampleBoolDTO request, ServerCallContext context)
        {
            var command = new UpdateSampleBoolCommand(_mapper.Map<Domain.Entities.HistoricalData.SampleBool>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

    }
}
