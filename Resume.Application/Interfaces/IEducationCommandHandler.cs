using Resume.Application.CQRS.Education.Command.CreateEducation;
using Resume.Application.CQRS.Education.Command.DeleteEducation;
using Resume.Application.CQRS.Education.Command.UpdateEducation;
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

        Task<bool> EditEducation(UpdateEducationcommand dto, CancellationToken cancellationToken);
        Task<ulong> CreateEducation(CreateEducationCommand dto, CancellationToken cancellationToken);
        Task<bool> DeleteEducation(DeleteEducationcommand dto, CancellationToken cancellationToken);
    }
}
