using Resume.Domain.Entity.Reservation;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository.Queries
{
    public class ReservationQueryRepository : GenericQueryRepository<ReservationDate>, IReservationQueryRepository
    {
        public ReservationQueryRepository(MongoDbContext dbContext) : base(dbContext)
        {

        }
    }

}
