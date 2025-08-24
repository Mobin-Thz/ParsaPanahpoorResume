using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Constructor
        private readonly IThingIDoService _thingIDoService;
        private readonly ICustomerFeedbackService _customerFeedbackService;
        private readonly ICustomerLogoService _customerLogoService;


        public HomeController(IThingIDoService thingIDoService, ICustomerFeedbackService customerFeedbackService, ICustomerLogoService customerLogoService)
        {
            _thingIDoService = thingIDoService;
            _customerFeedbackService = customerFeedbackService;
            _customerLogoService = customerLogoService;
        }
        #endregion
        public async Task<IActionResult> Index()
        {

            IndexPageViewModel model = new IndexPageViewModel()
            {
                ThingIDoList = await _thingIDoService.GetAllThingIDoForIndex(),
                CustomerFeedbakcList = await _customerFeedbackService.GetCustomerFeedbackForIndex(),
                CustomerLogoList = await _customerLogoService.GetCustomerLogosForIndexPage()
            };

            return View(model);

        }

    }
}
