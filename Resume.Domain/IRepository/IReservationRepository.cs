using Resume.Domain.Entity.Common;
using Resume.Domain.Entity.Reservation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.Repository;

public interface IReservationRepository
{
    Task<ReservationDate> AddAsync(ReservationDate entity, CancellationToken cancellationToken);

    void Delete(ReservationDate entity);
    Task<bool> DeleteAsync(ulong id, CancellationToken cancellationToken);


    void Update(ReservationDate entity);


    Task<ReservationDate?> GetByIdAsync(ulong id, CancellationToken cancellationToken);

    Task<List<ReservationDate>> GetAllAsync(CancellationToken cancellationToken = default);


}
