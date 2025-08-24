using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService : ICustomerLogoService
    {

        #region Constructor
        private readonly AppDbContext _context;

        public CustomerLogoService(AppDbContext context)
        {
            _context = context;
        }
        #endregion


        public async Task<List<CustomerLogoListViewModel>> GetCustomerLogosForIndexPage()
        {
            List<CustomerLogoListViewModel> customerLogos = await _context.CustomerLogos
                .OrderBy(c => c.Order)
                .Select(c => new CustomerLogoListViewModel()
                {
                    Id = c.Id,
                    Link = c.Link,
                    Logo = c.Logo,
                    LogoAlt = c.LogoAlt,
                    Order = c.Order
                })
                .ToListAsync();

            return customerLogos;
        }


    }
}
