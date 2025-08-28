using Resume.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Resume.Domain.Entity.Reservation;
using Resume.Infra.Data.SQLServer.Context;

namespace Resume.Infra.Data.Repository
{
    public class UnitOfWork(AppDbContext dbContext): IUnitOfWork
    {
        private readonly AppDbContext _dbContext = dbContext;


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}
