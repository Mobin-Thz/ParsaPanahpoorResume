using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTO.Education;
using Resume.Application.DTO.Reservation;
using Resume.Application.Interfaces;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Reservation;
using Resume.Web.Areas.Controllers;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers;

public class ReservationController : AdminBaseController
{
    #region Constructor
    private readonly IReservationCommandHandler _reservationCommand;
    private readonly IReservationQueryHandler _reservationQuery;

    public ReservationController(IReservationCommandHandler reservationCommand, IReservationQueryHandler reservationQuery)
    {
        _reservationCommand = reservationCommand;
        _reservationQuery = reservationQuery;
    }
    #endregion

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        => View(await _reservationQuery.GetListOfReservations(cancellationToken));



    [HttpGet]
    public async Task<IActionResult> LoadReservationFormModal(ulong id,
        CancellationToken cancellationToken = default)
    {
        if (id == 0) // Create
        {
            var model = await _reservationQuery.FillCreateReservationViewModel();
            return PartialView("_ReservationFormModalPartialCreate", model);
        }
        else // Edit
        {
            var model = await _reservationQuery.FillUpdateReservationViewModel(id, cancellationToken);
            return PartialView("_ReservationFormModalPartialEdit", model);
        }
    }
    //public async Task<IActionResult> SubmitReservationFormModal(CreateOrUpdateReservationViewModel Reservation , 
    //    CancellationToken cancellationToken = default)
    //{
    //    var result = await _reservationService.CreateOrEditReservationDate(Reservation , cancellationToken);

    //    if (result) return new JsonResult(new { status = "Success" });

    //    return new JsonResult(new { status = "Error" });
    //}

    [HttpPost]
    public async Task<IActionResult> CreateReservation(
        CreateReservationViewModel reservation,
        CancellationToken cancellationToken = default)
    {
        var result = await _reservationCommand.CreateReservationDate(reservation.ReservationDate, cancellationToken);

        if (result)
            return Json(new { status = "Success" });

        return Json(new { status = "Error" });
    }

    [HttpPost]
    public async Task<IActionResult> EditReservation(
        UpdateReservationViewModel reservation,
        CancellationToken cancellationToken = default)
    {
        var dto = new ReservationDateDto
        {
            Id = reservation.Id,
            ReservationDate = reservation.ReservationDate
        };

        var result = await _reservationCommand.EditReservationDate(dto, cancellationToken);

        if (result)
            return Json(new { status = "Success" });

        return Json(new { status = "Error" });
    }


    [HttpPost]
    public async Task<IActionResult> DeleteReservation(
        ulong id,
        CancellationToken cancellationToken = default)
    {
        var dto = new ReservationDateDto { Id = id };
        var result = await _reservationCommand.DeleteReservationDate(dto, cancellationToken);

        if (result)
            return Json(new { status = "Success" });

        return Json(new { status = "Error" });
    }
}
