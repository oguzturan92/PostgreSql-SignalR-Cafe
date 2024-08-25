using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.AboutDtos;
using KlassyCafePostgreSql.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.about = "active";

            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.about = "active";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            ViewBag.about = "active";
            
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("List", "About");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.about = "active";

            var value = await _aboutService.GetByIdAboutAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            ViewBag.about = "active";
            
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("List", "About");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("List", "About");
        }
    }
}