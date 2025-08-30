using Resume.Application.Common.Interfaces;
using Resume.Application.DTO;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Commands.EducationCommand
{

    public class EducationCommandHandler : IEducationCommandHandler
    {


        #region ctor
        private readonly IEducationRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EducationCommandHandler(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;

        }
        #endregion


        public async Task<bool> EditEducation(UpdateEducationDto dto, CancellationToken cancellationToken)
        {
            var education = await _educationRepository.GetByIdAsync(dto.Id, cancellationToken);
            if (education == null) return false;

            education.Title = dto.Title;
            education.Description = dto.Description;
            education.StartDate = dto.StartDate;
            education.EndDate = dto.EndDate;
            education.Order = dto.Order;

            _educationRepository.Update(education);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<ulong> CreateEducation(CreateEducationDto dto, CancellationToken cancellationToken)
        {
            var education = new Education
            {
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Order = dto.Order
            };

            await _educationRepository.AddAsync(education, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return education.Id; 
        }


        public async Task<bool> DeleteEducation(DeleteEducationDto dto, CancellationToken cancellationToken)
        {
            var education = new Education { Id = dto.Id }; 
            _educationRepository.Delete(education);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
