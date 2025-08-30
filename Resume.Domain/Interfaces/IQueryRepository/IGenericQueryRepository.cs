using Resume.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.Interfaces.IQueryRepository
{
    public interface IGenericQueryRepository<TEntity> where TEntity : class, IEntity
    {

        Task<TEntity> GetByIdAsync(ulong id, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}
