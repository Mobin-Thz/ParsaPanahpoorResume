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


        public Task<CreateReservationViewModel> FillCreateReservationViewModel()
        {
            return Task.FromResult(new CreateReservationViewModel());
        }

        public async Task<UpdateReservationViewModel> FillUpdateReservationViewModel(ulong id, CancellationToken cancellationToken)
        {
            ReservationDate reservationDate = await GetReservationDate(id, cancellationToken);

            if (reservationDate == null)
                return null; 

            return new UpdateReservationViewModel
            {
                Id = reservationDate.Id,
                ReservationDate = reservationDate.Date.ToShamsi()
            };
        }

    }
}
