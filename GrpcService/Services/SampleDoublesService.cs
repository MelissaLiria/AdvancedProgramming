using Application.Samples.Commands.CreateSampleDouble;
using Application.Samples.Commands.DeleteSampleDouble;
using Application.Samples.Commands.UpdateSampleDouble;
using Application.Samples.Queries.GetAllSampleDoubles;
using Application.Samples.Queries.GetAverageOfSampleDoubles;
using Application.Samples.Queries.GetSampleDoubleByTimeSpan;
using Application.Samples.Queries.GetSampleDoubleByVariableId;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;
using MediatR;

namespace GrpcService.Services
{
    public class SampleDoublesService : SampleDouble.SampleDoubleBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SampleDoublesService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<SampleDoubleDTO> CreateSampleDouble(CreateSampleDoubleRequest request, ServerCallContext context)
        {
            var command = new CreateSampleDoubleCommand(
                new Guid(request.VariableId),
                request.Value);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<SampleDoubleDTO>(result));
        }

        public override Task<Empty> DeleteSampleDouble(DeleteSampleRequest request, ServerCallContext context)
        {
            var command = new DeleteSampleDoubleCommand(new Guid(request.VariableId), DateTime.Parse(request.DateTime));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<SampleDoubles> GetAllSampleDoubles(Empty request, ServerCallContext context)
        {
            var query = new GetAllSampleDoublesQuery();

            var result = _mediator.Send(query).Result;

            var sampleDoubleDTOs = new SampleDoubles();
            sampleDoubleDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleDoubleDTO>(m)));

            return Task.FromResult(sampleDoubleDTOs);
        }

        public override Task<SampleDoubles> GetSampleDoubleByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            var query = new GetSampleDoubleByTimeSpanQuery(DateTime.Parse(request.StartTime), DateTime.Parse(request.EndTime));

            var result = _mediator.Send(query).Result;

            var sampleDoubleDTOs = new SampleDoubles();
            sampleDoubleDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleDoubleDTO>(m)));

            return Task.FromResult(sampleDoubleDTOs);
        }

        public override Task<SampleDoubles> GetSampleDoubleByVariableId(GetRequest request, ServerCallContext context)
        {
            var query = new GetSampleDoubleByVariableIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            var sampleDoubleDTOs = new SampleDoubles();
            sampleDoubleDTOs.Items.AddRange(result.Select(m => _mapper.Map<SampleDoubleDTO>(m)));

            return Task.FromResult(sampleDoubleDTOs);
        }

        public override Task<Empty> UpdateSampleDouble(SampleDoubleDTO request, ServerCallContext context)
        {
            var command = new UpdateSampleDoubleCommand(_mapper.Map<Domain.Entities.HistoricalData.SampleDouble>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Average> GetAverageOfSampleDoubles(SampleDoubles request, ServerCallContext context)
        {
            var samples = new List<Domain.Entities.HistoricalData.SampleDouble>();
            foreach (SampleDoubleDTO sample in request.Items)
            {
                samples.Add(_mapper.Map<Domain.Entities.HistoricalData.SampleDouble>(sample));
            }
            var query = new GetAverageOfSampleDoublesQuery(samples);
            var result = _mediator.Send(query).Result;
            Average avg = new Average() { Average_ = result };
            return Task.FromResult(avg);
        }
    }
}
