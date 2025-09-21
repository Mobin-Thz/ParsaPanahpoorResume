

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.Models;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Application.Common.Interfaces;

namespace Resume.Application.CQRS.Education.Command.CreateEducation
{

    public class CreateEducationHandler : IRequestHandler<CreateEducationCommand, ulong>
    {

        #region ctor
        private readonly IEducationCommandRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEducationHandler(IEducationCommandRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;

        }
        #endregion

        public async Task<ulong> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var education = new Resume.Domain.Models.Education
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Order = request.Order
            };

            await _educationRepository.AddAsync(education, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return education.Id;
        }

    }
}
