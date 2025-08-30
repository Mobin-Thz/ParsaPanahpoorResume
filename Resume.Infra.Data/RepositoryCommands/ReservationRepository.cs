using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Repository;
using Resume.Infra.Data.SQLServer.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository;

public class ReservationRepository : GenericCommandRepository<ReservationDate>, IReservationRepository

{
    #region Ctor

    private readonly SqlDbContext _context;

    public ReservationRepository(SqlDbContext dbContext):base(dbContext)
    {
        _context = dbContext;
    }


    #endregion



}


