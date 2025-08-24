using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.ViewComponent;
using System.Threading.Tasks;

namespace Resume.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        #region Constructor
        private readonly ISocialMediaService _socialMediaService;
        private readonly IInformationService _informationService;

        public SideBarViewComponent(ISocialMediaService socialMediaService, IInformationService informationService)
        {
            _socialMediaService = socialMediaService;
            _informationService = informationService;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            SideBarViewModel model = new SideBarViewModel()
            {
                SocialMedias = await _socialMediaService.GetAllSocialMedias(),
                information = await _informationService.GetInformation()
            };

            return View("SideBar", model);
        }

    }
}
