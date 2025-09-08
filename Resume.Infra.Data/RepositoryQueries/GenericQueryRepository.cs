using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Resume.Application.Common.Interfaces;
using Resume.Domain.Entity.Common;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Infra.Data.MongoDb;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.RepositoryQueries
{

    public class GenericQueryRepository<TEntity> : IGenericQueryRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly PostgresDbContext _dbContext;

        public GenericQueryRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity?> GetByIdAsync(ulong Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == Id, cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

    }
}
