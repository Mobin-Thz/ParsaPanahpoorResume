using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {

        #region Constructor
        private readonly AppDbContext _context;

        public CustomerFeedbackService(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<CustomerFeedback> GetCustomerFeedbackById(long id)
        {
            return await _context.CustomerFeedbacks.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CustomerFeedbackViewModel>> GetCustomerFeedbackForIndex()
        {
            List<CustomerFeedbackViewModel> customerFeedbacks = await _context.CustomerFeedbacks
                .OrderBy(c => c.Order)
                .Select(c => new CustomerFeedbackViewModel()
                {
                    Order = c.Order,
                    Avatar = c.Avatar,
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return customerFeedbacks;
        }


        public async Task<bool> CreateOrEditCustomerFeedback(CreateOrEditCustomerFeedbackViewModel customerFeedback)
        {
            if (customerFeedback.Id == 0)
            {
                var newCustomerFeedback = new CustomerFeedback()
                {
                    Avatar = customerFeedback.Avatar,
                    Description = customerFeedback.Description,
                    Name = customerFeedback.Name,
                    Order = customerFeedback.Order
                };

                await _context.CustomerFeedbacks.AddAsync(newCustomerFeedback);
                await _context.SaveChangesAsync();

                return true;
            }


            CustomerFeedback currentCustomerFeedback = await GetCustomerFeedbackById(customerFeedback.Id);

            if (currentCustomerFeedback == null) return false;

            currentCustomerFeedback.Avatar = customerFeedback.Avatar;
            currentCustomerFeedback.Description = customerFeedback.Description;
            currentCustomerFeedback.Name = customerFeedback.Name;
            currentCustomerFeedback.Order = customerFeedback.Order;

            _context.CustomerFeedbacks.Update(currentCustomerFeedback);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CreateOrEditCustomerFeedbackViewModel> FillCreateOrEditCustomerFeedbackViewModel(long id)
        {
            if (id == 0) return new CreateOrEditCustomerFeedbackViewModel() {Id = 0 };

            CustomerFeedback customerFeedback = await GetCustomerFeedbackById(id);

            if (customerFeedback == null) return new CreateOrEditCustomerFeedbackViewModel() { Id = 0 };

            return new CreateOrEditCustomerFeedbackViewModel()
            {
                Id = customerFeedback.Id,
                Avatar = customerFeedback.Avatar,
                Description = customerFeedback.Description,
                Name = customerFeedback.Name,
                Order = customerFeedback.Order
            };

        }

        public async Task<bool> DeleteCustomerFeedback(long id)
        {
            CustomerFeedback customerFeedback = await GetCustomerFeedbackById(id);

            if (customerFeedback == null) return false;

            _context.CustomerFeedbacks.Remove(customerFeedback);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
