
using Application.Abstract;
using Contracts;
using Contracts.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.UpdateSampleBool
{
    public class UpdateSampleBoolCommandHandler
        : ICommandHandler<UpdateSampleBoolCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSampleBoolCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSampleBoolCommand request, CancellationToken cancellationToken)
        {
            _sampleRepository.UpdateSample(request.SampleBool);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
