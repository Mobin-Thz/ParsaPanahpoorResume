using Resume.Application.Commands.EducationCommand;
using Resume.Application.Common.Interfaces;
using Resume.Application.DTO;
using Resume.Application.Interfaces;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.RepositoryQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Queries.EducationQuery
{
    public class EducationQueryHandler : IEducationQueryHandler
    {

        #region ctor
        private readonly IEducationQueryRepository _educationRepository;

        public EducationQueryHandler(IEducationQueryRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;

        }
        #endregion


        public async Task<EducationViewModel> GetEducationById(ulong id, CancellationToken cancellationToken)
        {
            return await _educationRepository.GetByIdAsync(id, cancellationToken);
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

        public async Task<UpdateEducationDto?> GetEducationForEditAsync(ulong id, CancellationToken cancellationToken)
        {
            var education = await _educationRepository.GetByIdAsync(id, cancellationToken);
            if (education == null) return null;

            return new UpdateEducationDto
            {
                Id = education.Id,
                Title = education.Title,
                Description = education.Description,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Order = education.Order
            };
        }
    }
}
