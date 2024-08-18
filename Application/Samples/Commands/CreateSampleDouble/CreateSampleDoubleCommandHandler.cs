using Application.Abstract;
using Contracts;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.CreateSampleDouble
{
    public class CreateSampleDoubleCommandHandler
        : ICommandHandler<CreateSampleDoubleCommand, SampleDouble>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSampleDoubleCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<SampleDouble> Handle(CreateSampleDoubleCommand request, CancellationToken cancellationToken)
        {
            SampleDouble result = new SampleDouble(
                request.VariableId,
                request.Value);

            _sampleRepository.AddSample(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
