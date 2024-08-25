using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.ReservationDtos;
using KlassyCafePostgreSql.Services.ReservationServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.reservation = "active";

            var values = await _reservationService.GetAllReservationAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.reservation = "active";

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationDto createReservationDto)
        {
            ViewBag.reservation = "active";

            await _reservationService.CreateReservationAsync(createReservationDto);
            return RedirectToAction("List", "Reservation");
        }

        [HttpPost]
        public async Task<IActionResult> CreateHome(CreateReservationDto createReservationDto)
        {
            await _reservationService.CreateReservationAsync(createReservationDto);
            return Json("Success");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.reservation = "active";

            var value = await _reservationService.GetByIdReservationAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateReservationDto updateReservationDto)
        {
            ViewBag.reservation = "active";

            await _reservationService.UpdateReservationAsync(updateReservationDto);
            return RedirectToAction("List", "Reservation");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return RedirectToAction("List", "Reservation");
        }
    }
}