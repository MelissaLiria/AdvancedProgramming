using Application.Abstract;
using Contracts;
using Contracts.Samples;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.CreateSampleInt
{
    public class CreateSampleIntCommandHandler
        : ICommandHandler<CreateSampleIntCommand, SampleInt>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSampleIntCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<SampleInt> Handle(CreateSampleIntCommand request, CancellationToken cancellationToken)
        {
            SampleInt result = new SampleInt(
                request.VariableId,
                request.Value);

            _sampleRepository.AddSample(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
