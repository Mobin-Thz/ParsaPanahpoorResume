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


    }
}
