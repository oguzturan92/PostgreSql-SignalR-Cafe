using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Services.MenuServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.ViewComponents.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;

        public MenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _menuService.GetAllTrueMenuAsync();
            return View(values);
        }  
    }
}