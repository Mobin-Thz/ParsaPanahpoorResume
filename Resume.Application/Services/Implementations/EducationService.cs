using Microsoft.EntityFrameworkCore;
using Resume.Application.Commands.EducationCommand;
using Resume.Application.Common.Interfaces;
using Resume.Application.Services.Interfaces;
using Resume.Domain.IRepository;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.Context;
using Resume.Infra.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class EducationService : IEducationService
    {

        #region ctor
        private readonly IEducationRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EducationService(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;

        }
        #endregion


        public async Task<EducationCommand> GetEducationById(ulong id, CancellationToken cancellationToken)
        {
            return await _educationRepository.GetByIdAsync(id,  cancellationToken);
        }

        public async Task<List<EducationViewModel>> GetAllEducations(CancellationToken cancellationToken)
        {
            var educations = await _educationRepository.GetAllAsync(cancellationToken);

            return educations
                .OrderBy(c => c.Order)
                .Select(c => new EducationViewModel
                {
                    Description = c.Description,
                    EndDate = c.EndDate,
                    Id = c.Id,
                    StartDate = c.StartDate,
                    Title = c.Title,
                    Order = c.Order
                })
                .ToList();
        }

        public async Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(ulong id, CancellationToken cancellationToken)
        {
            if (id == 0) return new CreateOrEditEducationViewModel() { Id = 0 };

            EducationCommand education = await GetEducationById(id, cancellationToken);

            if (education == null) return new CreateOrEditEducationViewModel() { Id = 0 };

            return new CreateOrEditEducationViewModel()
            {
                Id = education.Id,
                Description = education.Description,
                EndDate = education.EndDate,
                Order = education.Order,
                StartDate = education.StartDate,
                Title = education.Title
            };
        }

        public async Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education, CancellationToken cancellationToken)
        {
            if (education.Id == 0)
            {
                var newEducation = new EducationCommand()
                {
                    Description = education.Description,
                    EndDate = education.EndDate,
                    Order = education.Order,
                    StartDate = education.StartDate,
                    Title = education.Title
                };

                await _educationRepository.AddAsync(newEducation, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            EducationCommand currentEducation = await GetEducationById(education.Id,  cancellationToken);

            if (currentEducation == null) return false;

            currentEducation.Description = education.Description;
            currentEducation.EndDate = education.EndDate;
            currentEducation.Order = education.Order;
            currentEducation.StartDate = education.StartDate;
            currentEducation.Title = education.Title;

            _educationRepository.Update(currentEducation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEducation(ulong id, CancellationToken cancellationToken)
        {
            EducationCommand education = await GetEducationById(id,  cancellationToken);

            if (education == null) return false;

            _educationRepository.Delete(education);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

    }
}
