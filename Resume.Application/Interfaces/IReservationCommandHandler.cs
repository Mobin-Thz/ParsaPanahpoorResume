using Resume.Application.CQRS.Reservation.Command;
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
    public interface IReservationCommandHandler
    {

        Task<bool> CreateReservationDate(string date,
            CancellationToken cancellationToken);

        Task<bool> EditReservationDate(ReservationDateDto dto,
            CancellationToken cancellationToken);

        Task<bool> DeleteReservationDate(ReservationDateDto dto,
            CancellationToken cancellationToken);

    }
}
