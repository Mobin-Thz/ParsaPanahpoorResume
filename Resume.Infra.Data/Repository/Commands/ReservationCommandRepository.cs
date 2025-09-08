using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Infra.Data.SQLServer.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Infra.Data.Repository.Commands;

public class ReservationCommandRepository : GenericCommandRepository<ReservationDate>, IReservationCommandRepository

{
    #region Ctor

    private readonly AppDbContext _context;

    public ReservationCommandRepository(AppDbContext dbContext):base(dbContext)
    {
        _context = dbContext;
    }


    #endregion



}


