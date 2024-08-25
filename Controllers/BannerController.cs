using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.BannerDtos;
using KlassyCafePostgreSql.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.banner = "active";

            var values = await _bannerService.GetAllBannerAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.banner = "active";

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            ViewBag.banner = "active";

            await _bannerService.CreateBannerAsync(createBannerDto);
            return RedirectToAction("List", "Banner");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.banner = "active";

            var value = await _bannerService.GetByIdBannerAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            ViewBag.banner = "active";

            await _bannerService.UpdateBannerAsync(updateBannerDto);
            return RedirectToAction("List", "Banner");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.DeleteBannerAsync(id);
            return RedirectToAction("List", "Banner");
        }
    }
}