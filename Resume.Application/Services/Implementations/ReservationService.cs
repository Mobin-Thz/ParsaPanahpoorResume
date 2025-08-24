using Resume.Application.Services.Interfaces;
using Resume.Domain.Entity.Reservation;
using Resume.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Resume.Application.Convertors;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Reservation;
using Resume.Application.Common.Interfaces;

namespace Resume.Application.Services.Implementations;

public class ReservationService : IReservationService
{
    #region ctor
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;

    }


    #endregion

    public async Task<List<ReservationDate>> GetListOfReservations(CancellationToken cancellationToken)
        => await _reservationRepository.GetAllAsync(cancellationToken);

    public async Task<bool> CreateReservation(string date , 
        CancellationToken cancellationToken)
    {
        await _reservationRepository.AddAsync(new ReservationDate()
        {
            Date = date.ToMiladiDateTime()
        } , cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<ReservationDate> GetReservationDate(ulong reservationDateId,
        CancellationToken cancellationToken)
        => await _reservationRepository.GetByIdAsync(reservationDateId, cancellationToken);



    public async Task<bool> EditReservationDate(ulong reservationDateId ,
        string date ,   
        CancellationToken cancellationToken)
    {
        //Find original record 
        var originalRecord = await _reservationRepository.GetByIdAsync(reservationDateId , cancellationToken);
        if (originalRecord == null)
            return false;

        originalRecord.Date = date.ToMiladiDateTime();

        _reservationRepository.Update(originalRecord);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }



    public async Task<CreateOrUpdateReservationViewModel> FillCreateOrUpdateReservationViewModel(ulong id , 
        CancellationToken cancellationToken)
    {
        if (id == 0) 
            return new CreateOrUpdateReservationViewModel() { Id = 0 };

        ReservationDate reservationDate = await GetReservationDate(id , cancellationToken);

        if (reservationDate == null) 
            return new CreateOrUpdateReservationViewModel() { Id = 0 };

        return new CreateOrUpdateReservationViewModel()
        {
            Id = reservationDate.Id,
            ReservationDate = reservationDate.Date.ToShamsi(),
        };
    }

    public async Task<bool> CreateOrEditReservationDate(CreateOrUpdateReservationViewModel reservationDate ,
        CancellationToken cancellationToken)
    {
        if (reservationDate.Id == 0)
        {
            var newReservationDate = new ReservationDate()
            {
                Date = reservationDate.ReservationDate.ToMiladiDateTime()
            };

            await _reservationRepository.AddAsync(newReservationDate , cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        ReservationDate currentReservationDate = await GetReservationDate(reservationDate.Id , cancellationToken);

        if (currentReservationDate == null) 
            return false;

        currentReservationDate.Date = reservationDate.ReservationDate.ToMiladiDateTime();

        _reservationRepository.Update(currentReservationDate);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteReservationDate(ulong id , CancellationToken cancellationToken)
    {
        ReservationDate reservationDate = await GetReservationDate(id , cancellationToken);
        if (reservationDate == null) 
            return false;

        reservationDate.IsDelete = true;

        _reservationRepository.Delete(reservationDate);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
