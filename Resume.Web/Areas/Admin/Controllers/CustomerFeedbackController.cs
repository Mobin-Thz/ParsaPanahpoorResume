using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Eetensions;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Web.Areas.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class CustomerFeedbackController : AdminBaseController
    {

        #region Constructor
        private readonly ICustomerFeedbackService _customerFeedbackService;

        public CustomerFeedbackController(ICustomerFeedbackService customerFeedbackService)
        {
            _customerFeedbackService = customerFeedbackService;
        }
        #endregion


        public async Task<IActionResult> Index()
        {
            return View(await _customerFeedbackService.GetCustomerFeedbackForIndex());
        }

        public async Task<IActionResult> LoadCustomrFeedbackFormModal(long id)
        {
            CreateOrEditCustomerFeedbackViewModel result = await _customerFeedbackService.FillCreateOrEditCustomerFeedbackViewModel(id);
            return PartialView("_CustomerFeedbackFormModalPartial", result);
        }

        public async Task<IActionResult> SubmitCustomerFeedbackFormModal(CreateOrEditCustomerFeedbackViewModel customerFeedback)
        {
            var result = await _customerFeedbackService.CreateOrEditCustomerFeedback(customerFeedback);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteCustomerFeedback(long id)
        {
            var result = await _customerFeedbackService.DeleteCustomerFeedback(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        [HttpPost]
        public async Task<IActionResult> UploadCustomerFeedbackImageAjax(IFormFile file)
        {
            if (file !=null)
            {
                if (Path.GetExtension(file.FileName) == ".png" || Path.GetExtension(file.FileName) == ".jpeg" || Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.CustomerFeedbackAvatarServer);
                    return new JsonResult(new { status = "Success", imageName = imageName });

                }
                else
                {
                    return new JsonResult(new { status = "Error" });
                }
            }
            else
            {
                return new JsonResult(new { status = "Error" });
            }
        }




    }
}
