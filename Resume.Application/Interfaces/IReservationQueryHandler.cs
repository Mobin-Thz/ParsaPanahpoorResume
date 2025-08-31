using Resume.Domain.Entity.Reservation;
using Resume.Domain.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IReservationQueryHandler
    {
        Task<CreateOrUpdateReservationViewModel> FillCreateOrUpdateReservationViewModel(ulong id,
         CancellationToken cancellationToken);

        Task<List<ReservationDate>> GetListOfReservations(CancellationToken cancellationToken);


        Task<ReservationDate> GetReservationDate(ulong reservationDateId, CancellationToken cancellationToken);

    }
}
