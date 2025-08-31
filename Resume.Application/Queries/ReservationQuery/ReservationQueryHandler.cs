using Resume.Application.Common.Interfaces;
using Resume.Application.Convertors;
using Resume.Application.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Domain.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Queries.ReservationQuery
{
    public class ReservationQueryHandler: IReservationQueryHandler
    {

        #region ctor
        private readonly IReservationQueryRepository _reservationRepository;

        public ReservationQueryHandler(IReservationQueryRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }


        #endregion


        public async Task<ReservationDate> GetReservationDate(ulong reservationDateId,CancellationToken cancellationToken)
            => await _reservationRepository.GetByIdAsync(reservationDateId, cancellationToken);


        public async Task<List<ReservationDate>> GetListOfReservations(CancellationToken cancellationToken)
            => await _reservationRepository.GetAllAsync(cancellationToken);



        public async Task<CreateOrUpdateReservationViewModel> FillCreateOrUpdateReservationViewModel(ulong id,
            CancellationToken cancellationToken)
        {
            if (id == 0)
                return new CreateOrUpdateReservationViewModel() { Id = 0 };

            ReservationDate reservationDate = await GetReservationDate(id, cancellationToken);

            if (reservationDate == null)
                return new CreateOrUpdateReservationViewModel() { Id = 0 };

            return new CreateOrUpdateReservationViewModel()
            {
                Id = reservationDate.Id,
                ReservationDate = reservationDate.Date.ToShamsi(),
            };
        }
    }
}
