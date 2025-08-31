using Resume.Application.DTO.Education;
using Resume.Domain.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IEducationCommandHandler
    {

        Task<bool> EditEducation(UpdateEducationDto dto, CancellationToken cancellationToken);
        Task<ulong> CreateEducation(CreateEducationDto dto, CancellationToken cancellationToken);
        Task<bool> DeleteEducation(DeleteEducationDto dto, CancellationToken cancellationToken);
    }
}
