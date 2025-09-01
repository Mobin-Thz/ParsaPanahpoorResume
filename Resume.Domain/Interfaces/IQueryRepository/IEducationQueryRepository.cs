using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.Interfaces.IQueryRepository
{
    public interface IEducationQueryRepository
    {

        Task<Education?> GetByIdAsync(ulong id, CancellationToken cancellationToken);

        Task<List<Education>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}
