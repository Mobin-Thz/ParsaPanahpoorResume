using Microsoft.AspNetCore.Mvc;
using Resume.Application.DTO.Education;
using Resume.Application.Interfaces;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Education;
using Resume.Web.Areas.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Constructor
        private readonly IEducationCommandHandler _educationCommand;
        private readonly IEducationQueryHandler _educationQuery;

        public EducationController(IEducationCommandHandler educationCommand, IEducationQueryHandler educationQuery)
        {
            _educationCommand = educationCommand;
            _educationQuery = educationQuery;
        }
        #endregion

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _educationQuery.GetAllEducations(cancellationToken));
        }

        public async Task<IActionResult> LoadEducationFormModal(ulong id, CancellationToken cancellationToken)
        {
            UpdateEducationDto dto = await _educationQuery.GetEducationForEditAsync(id, cancellationToken)
                                    ?? new UpdateEducationDto { Id = 0 }; // empty for create

            return PartialView("_EducationFormModalPartial", dto);
        }


        //[HttpPost]
        //public async Task<IActionResult> SubmitEducationFormModal(
        //    UpdateEducationDto dto, CancellationToken cancellationToken)
        //{
        //    bool result;

        //    if (dto.Id == 0)
        //    {
        //        var createDto = new CreateEducationDto
        //        {
        //            Title = dto.Title,
        //            Description = dto.Description,
        //            StartDate = dto.StartDate,
        //            EndDate = dto.EndDate,
        //            Order = dto.Order
        //        };

        //        await _educationCommand.CreateEducation(createDto, cancellationToken);
        //        result = true;
        //    }
        //    else
        //    {
        //        result = await _educationCommand.EditEducation(dto, cancellationToken);
        //    }

        //    if (result)
        //        return Json(new { status = "Success" });

        //    return Json(new { status = "Error" });
        //}

        [HttpPost]
        public async Task<IActionResult> CreateEducation(CreateEducationDto dto, CancellationToken cancellationToken)
        {
            if (dto == null) return BadRequest();

            var id = await _educationCommand.CreateEducation(dto, cancellationToken);

            if (id > 0)
                return Json(new { status = "Success", id });

            return Json(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> EditEducation(UpdateEducationDto dto, CancellationToken cancellationToken)
        {
            if (dto == null || dto.Id == 0) return BadRequest();

            var result = await _educationCommand.EditEducation(dto, cancellationToken);

            if (result)
                return Json(new { status = "Success" });

            return Json(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEducation(ulong id, CancellationToken cancellationToken)
        {
            var dto = new DeleteEducationDto { Id = id };
            bool result = await _educationCommand.DeleteEducation(dto, cancellationToken);

            if (result) return Json(new { status = "Success" });

            return Json(new { status = "Error" });
        }


    }
}
