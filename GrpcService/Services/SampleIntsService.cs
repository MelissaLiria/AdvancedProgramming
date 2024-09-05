using Application.Samples.Commands.CreateSampleInt;
using Application.Samples.Commands.DeleteSampleInt;
using Application.Samples.Commands.UpdateSampleInt;
using Application.Samples.Queries.GetAllSampleInts;
using Application.Samples.Queries.GetAverageOfSampleInts;
using Application.Samples.Queries.GetSampleIntByTimeSpan;
using Application.Samples.Queries.GetSampleIntByVariableId;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class SampleIntsService : SampleInt.SampleIntBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SampleIntsService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SampleIntDTO> CreateSampleInt(CreateSampleIntRequest request, ServerCallContext context)
        {
            var command = new CreateSampleIntCommand(
                new Guid(request.VariableId),
                request.Value);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SampleIntDTO>(result));
        }

        public override Task<Empty> DeleteSampleInt(DeleteSampleRequest request, ServerCallContext context)
        {
            var command = new DeleteSampleIntCommand(new Guid(request.VariableId), DateTime.Parse(request.DateTime));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<SampleInts> GetAllSampleInts(Empty request, ServerCallContext context)
        {
            var query = new GetAllSampleIntsQuery();

            var result = _mediator.Send(query).Result;

            var sampleIntDTOs = new SampleInts();
            sampleIntDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleIntDTO>(m)));

            return Task.FromResult(sampleIntDTOs);
        }

        public override Task<SampleInts> GetSampleIntByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            var query = new GetSampleIntByTimeSpanQuery(DateTime.Parse(request.StartTime), DateTime.Parse(request.EndTime));

            var result = _mediator.Send(query).Result;

            var sampleIntDTOs = new SampleInts();
            sampleIntDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleIntDTO>(m)));

            return Task.FromResult(sampleIntDTOs);
        }

        public override Task<SampleInts> GetSampleIntByVariableId(GetRequest request, ServerCallContext context)
        {
            var query = new GetSampleIntByVariableIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            var sampleIntDTOs = new SampleInts();
            sampleIntDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleIntDTO>(m)));

            return Task.FromResult(sampleIntDTOs);
        }

        public override Task<Empty> UpdateSampleInt(SampleIntDTO request, ServerCallContext context)
        {
            var command = new UpdateSampleIntCommand(_mapper.Map<Domain.Entities.HistoricalData.SampleInt>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());    
        }

        public override Task<Average> GetAverageOfSampleInts(SampleInts request, ServerCallContext context)
        {
            var samples = new List<Domain.Entities.HistoricalData.SampleInt>();
            foreach(SampleIntDTO sample in request.Items)
            {
                samples.Add(_mapper.Map<Domain.Entities.HistoricalData.SampleInt>(sample));
            }
            var query = new GetAverageOfSampleIntsQuery(samples);
            var result = _mediator.Send(query).Result;
            Average avg = new Average() { Average_ = result};
            return Task.FromResult(avg);
        }

    }
}
