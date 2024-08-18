using Application.Abstract;
using Application.Samples.Commands.CreateSampleInt;
using Contracts;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.DeleteSampleInt
{
    public class DeleteSampleIntCommandHandler
        : ICommandHandler<DeleteSampleIntCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSampleIntCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSampleIntCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<SampleInt> samples = _sampleRepository.GetSamplesByTimeSpan<SampleInt>(request.DateTime, request.DateTime).ToList();
            SampleInt? sampleToDelete = samples.FirstOrDefault(x => x.VariableId == request.VariableId);
            if (sampleToDelete == null)
                return Task.CompletedTask;

            _sampleRepository.DeleteSample(sampleToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
