using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.ViewComponents.Reservation
{
    public class ReservationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }  
    }
}