using Resume.Domain.Entity.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {

        Task<int> SaveChangesAsync();

    }
}
