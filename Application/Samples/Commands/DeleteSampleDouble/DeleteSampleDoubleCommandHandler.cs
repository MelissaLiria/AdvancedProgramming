using Application.Abstract;
using Contracts;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.DeleteSampleDouble
{
    public class DeleteSampleDoubleCommandHandler
        : ICommandHandler<DeleteSampleDoubleCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSampleDoubleCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteSampleDoubleCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<SampleDouble> samples = _sampleRepository.GetSamplesByTimeSpan<SampleDouble>(request.DateTime, request.DateTime).ToList();
            SampleDouble? sampleToDelete = samples.FirstOrDefault(x => x.VariableId == request.VariableId);
            if (sampleToDelete == null)
                return Task.CompletedTask;

            _sampleRepository.DeleteSample(sampleToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
