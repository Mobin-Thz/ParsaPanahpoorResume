using Resume.Application.Common.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Infra.Data.MongoDb;
using Resume.Infra.Data.SQLServer.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly PostgresDbContext _postgresqlDbContext;

        public UnitOfWork(AppDbContext dbContext, PostgresDbContext postgresqlDbContext)
        {
            _dbContext = dbContext;
            _postgresqlDbContext = postgresqlDbContext;
        }


        public async Task<int> SaveChangesAsync()
        {
            await _postgresqlDbContext.SaveChangesAsync();

            return await _dbContext.SaveChangesAsync();
            

        }
    }
}
