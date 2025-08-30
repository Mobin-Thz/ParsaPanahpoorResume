using Microsoft.EntityFrameworkCore;
using Resume.Application.Common.Interfaces;
using Resume.Domain.Entity.Common;
using Resume.Domain.Interfaces;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Infra.Data.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.RepositoryQueries
{

    public class GenericQueryRepository<TEntity> : IGenericQueryRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly MongoDbContext _dbContext;
        public GenericQueryRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity?> GetByIdAsync(ulong id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

    }
}
