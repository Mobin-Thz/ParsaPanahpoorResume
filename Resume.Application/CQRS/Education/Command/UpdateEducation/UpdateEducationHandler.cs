using Resume.Application.Common.Interfaces;
using Resume.Application.CQRS.Education.Command.UpdateEducation;
using Resume.Domain.Interfaces.ICommandRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.CQRS.Education.Command.UpdateEducationHandler
{
    public class UpdateEducationHandler
    {

        #region ctor
        private readonly IEducationCommandRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEducationHandler(IEducationCommandRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;

        }
        #endregion


        public async Task<bool> EditEducation(UpdateEducationcommand dto, CancellationToken cancellationToken)
        {
            var education = new Resume.Domain.Models.Education
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Order = dto.Order
            };

            _educationRepository.Update(education);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
