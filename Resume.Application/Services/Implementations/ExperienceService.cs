using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Experience;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class ExperienceService : IExperienceService
    {

        #region Constructor
        private readonly AppDbContext _context;

        public ExperienceService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<List<ExperienceViewModel>> GetAllExperiences()
        {
            List<ExperienceViewModel> educations = await _context.Experiences
                    .OrderBy(c => c.Order)
                    .Select(c => new ExperienceViewModel()
                    {
                        Description = c.Description,
                        EndDate = c.EndDate,
                        Id = c.Id,
                        StartDate = c.StartDate,
                        Title = c.Title,
                        Order = c.Order
                    })
                    .ToListAsync();

            return educations;
        }
    }
}
