using Application.Abstract;
using Contracts;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.DeleteSampleBool
{
    public class DeleteSampleBoolCommandHandler
        : ICommandHandler<DeleteSampleBoolCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSampleBoolCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSampleBoolCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<SampleBool> samples = _sampleRepository.GetSamplesByTimeSpan<SampleBool>(request.DateTime, request.DateTime).ToList();
            SampleBool? sampleToDelete = samples.FirstOrDefault(x => x.VariableId == request.VariableId);
            if (sampleToDelete == null)
                return Task.CompletedTask;

            _sampleRepository.DeleteSample(sampleToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
