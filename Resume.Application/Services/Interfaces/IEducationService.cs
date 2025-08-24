using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<Education> GetEducationById(ulong id, CancellationToken cancellationToken);
        Task<List<EducationViewModel>> GetAllEducations(CancellationToken cancellationToken);
        Task<CreateOrEditEducationViewModel> FillCreateOrEditEducationViewModel(ulong id, CancellationToken cancellationToken);
        Task<bool> CreateOrEditEducation(CreateOrEditEducationViewModel education, CancellationToken cancellationToken);

        Task<bool> DeleteEducation(ulong id, CancellationToken cancellationToken);

    }
}
