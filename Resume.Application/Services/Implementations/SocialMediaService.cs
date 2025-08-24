using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.SocialMedia;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class SocialMediaService : ISocialMediaService
    {

        #region Constructor
        private readonly AppDbContext _context;

        public SocialMediaService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<List<SocialMediaViewModel>> GetAllSocialMedias()
        {
            List<SocialMediaViewModel> socialMedias = await _context.SocialMedias
                .OrderBy(s => s.Order)
                .Select(s => new SocialMediaViewModel()
                {
                    Id = s.Id,
                    Icon = s.Icon,
                    Order = s.Order,
                    Link = s.Link
                })
                .ToListAsync();

            return socialMedias;
        }



    }
}
