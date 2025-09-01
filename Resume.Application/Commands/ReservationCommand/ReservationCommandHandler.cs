using Resume.Application.Common.Interfaces;
using Resume.Application.Convertors;
using Resume.Application.DTO.Education;
using Resume.Application.DTO.Reservation;
using Resume.Application.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Commands.ReservationCommand
{
    public class ReservationCommandHandler : IReservationCommandHandler
    {

        #region ctor
        private readonly IReservationCommandRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationCommandHandler(IReservationCommandRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;

        }


        #endregion


        public async Task<bool> CreateReservationDate(string date,
            CancellationToken cancellationToken)
        {
            await _reservationRepository.AddAsync(new ReservationDate()
            {
                Date = date.ToMiladiDateTime()
            }, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


        public async Task<bool> EditReservationDate(ReservationDateDto dto, CancellationToken cancellationToken)
        {
            var reservation = new ReservationDate
            {
                Id = dto.Id,
                Date = dto.ReservationDate.ToMiladiDateTime()
            };

            _reservationRepository.Update(reservation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteReservationDate(ReservationDateDto dto, CancellationToken cancellationToken)
        {
            var reservationDate = new ReservationDate { Id = dto.Id };

            _reservationRepository.Delete(reservationDate);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


    }
}
