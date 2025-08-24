using Microsoft.EntityFrameworkCore;
using Resume.Application.Common.Interfaces;
using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Models;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{

    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class, IEntity


    {

        protected readonly AppDbContext _dbContext ;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }


        public void Delete(TEntity entity)
        {
             _dbContext.Set<TEntity>().Remove(entity);

        }

        public async Task<bool> DeleteAsync(ulong id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            Delete(entity);
            return true;
        }


        public void  Update (TEntity entity)
        {
             _dbContext.Set<TEntity>().Update(entity);
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
