using Microsoft.AspNetCore.Mvc;
using Resume.Application.Interfaces;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Web.Controllers
{
    public class ResumeController : Controller
    {

        #region Constructor
        private readonly IEducationQueryHandler _educationQuery;
        private readonly IExperienceService _experienceService;
        private readonly ISkillService _skillService;
        public ResumeController(IEducationQueryHandler educationQuery, IExperienceService experienceService, ISkillService skillService)
        {
            _educationQuery = educationQuery;
            _experienceService = experienceService;
            _skillService = skillService;
        }
        #endregion

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            ResumePageViewModel model = new ResumePageViewModel()
            {
                Educations = await _educationQuery.GetAllEducations(cancellationToken),
                Experiences = await _experienceService.GetAllExperiences(),
                Skills = await _skillService.GetAllSkills()
            };

            return View(model);
        }


    }
}
