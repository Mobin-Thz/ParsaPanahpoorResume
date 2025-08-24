using Resume.Domain.Entity.Common;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.IRepository
{
    public interface IEducationRepository
    {
        Task<Education> AddAsync(Education entity, CancellationToken cancellationToken);

        void Delete(Education entity);
        Task<bool> DeleteAsync(ulong id, CancellationToken cancellationToken);


        void Update(Education entity);


        Task<Education?> GetByIdAsync(ulong id, CancellationToken cancellationToken);

        Task<List<Education>> GetAllAsync(CancellationToken cancellationToken = default);


    }
}
