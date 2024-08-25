using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.ViewComponents.Banner
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public BannerViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerService.GetAllBannerAsync();
            return View(values);
        }  
    }
}