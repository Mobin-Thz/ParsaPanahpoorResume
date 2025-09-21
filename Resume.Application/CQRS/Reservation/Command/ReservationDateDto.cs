using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.CQRS.Reservation.Command
{
    public class ReservationDateDto
    {
         public ulong Id { get; set; }
        public string ReservationDate { get; set; }

    }
}
