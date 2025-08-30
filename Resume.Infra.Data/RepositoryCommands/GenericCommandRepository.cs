using Microsoft.EntityFrameworkCore;
using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Models;
using Resume.Infra.Data.SQLServer.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{

    public class GenericCommandRepository<TEntity>: IGenericCommandRepository<TEntity> where TEntity : class, IEntity


    {

        protected readonly SqlDbContext _dbContext ;

        public GenericCommandRepository(SqlDbContext dbContext)
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


        public void  Update (TEntity entity)
        {
             _dbContext.Set<TEntity>().Update(entity);
        }




    }
}
