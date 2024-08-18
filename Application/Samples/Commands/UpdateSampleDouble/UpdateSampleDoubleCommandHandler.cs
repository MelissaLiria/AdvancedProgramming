
using Application.Abstract;
using Contracts;
using Contracts.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.UpdateSampleDouble
{
    public class UpdateSampleDoubleCommandHandler
        : ICommandHandler<UpdateSampleDoubleCommand>
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSampleDoubleCommandHandler(ISampleRepository sampleRepository, IUnitOfWork unitOfWork)
        {
            _sampleRepository = sampleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateSampleDoubleCommand request, CancellationToken cancellationToken)
        {
            _sampleRepository.UpdateSample(request.SampleDouble);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
