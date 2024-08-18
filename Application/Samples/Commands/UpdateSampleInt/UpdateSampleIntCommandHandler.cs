using Application.Abstract;
using Contracts;
using Contracts.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.UpdateSampleInt
{
    public class UpdateSampleIntCommandHandler
        : ICommandHandler<UpdateSampleIntCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSampleIntCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSampleIntCommand request, CancellationToken cancellationToken)
        {
            _sampleRepository.UpdateSample(request.SampleInt);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
