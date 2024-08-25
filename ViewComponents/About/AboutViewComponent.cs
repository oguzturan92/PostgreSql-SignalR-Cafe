using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.ViewComponents.About
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutService.GetByFirstAboutAsync();
            return View(value);
        }        
    }
}