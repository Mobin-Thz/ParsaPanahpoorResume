using Resume.Domain.Entity.Reservation;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Domain.Interfaces.ICommandRepository
{
    public interface IReservationCommandRepository
    {

        Task<ReservationDate> AddAsync(ReservationDate entity, CancellationToken cancellationToken);

        void Delete(ReservationDate entity);

        void Update(ReservationDate entity);


    }
}
