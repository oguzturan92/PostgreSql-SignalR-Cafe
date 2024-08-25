using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlassyCafePostgreSql.Dtos.AdminDtos
{
    public class AdminListDto
    {
        public int TableCount { get; set; }
        public int ReservationCount { get; set; }
        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
    }
}