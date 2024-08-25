using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public string ReservationFullname { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationPhone { get; set; }
        public int ReservationPerson { get; set; }
        public string ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public string ReservationBody { get; set; }
    }
}