using Resume.Domain.Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.Interfaces.IQueryRepository
{
    public interface IReservationQueryRepository
    {

        Task<ReservationDate?> GetByIdAsync(ulong id, CancellationToken cancellationToken);

        Task<List<ReservationDate>> GetAllAsync(CancellationToken cancellationToken = default);

    }
}
