using Resume.Application.Commands.EducationCommand;
using Resume.Application.DTO;
using Resume.Application.Queries.EducationQuery;
using Resume.Domain.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IEducationQueryHandler
    {
        Task<EducationViewModel> GetEducationById(ulong id, CancellationToken cancellationToken);
        Task<List<EducationViewModel>> GetAllEducations(CancellationToken cancellationToken);
        Task<UpdateEducationDto?> GetEducationForEditAsync(ulong id, CancellationToken cancellationToken);


    }
}
