using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class PortfolioController : Controller
    {
        #region Constructor
        private readonly IPortfolioService _porfolioService;

        public PortfolioController(IPortfolioService porfolioService)
        {
            _porfolioService = porfolioService;
        }
        #endregion


        public async Task<IActionResult> Index()
        {

            PortfolioPageViewModel model = new PortfolioPageViewModel() {
                Portfolios = await _porfolioService.GetAllPortfolios(),
                PortfolioCategories = await _porfolioService.GetAllPortfolioCategories()
            };

            return View(model);
        }
    }
}
