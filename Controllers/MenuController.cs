using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.MenuDtos;
using KlassyCafePostgreSql.Services.MenuServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.menu = "active";

            var values = await _menuService.GetAllMenuAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.menu = "active";

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuDto createMenuDto)
        {
            ViewBag.menu = "active";

            await _menuService.CreateMenuAsync(createMenuDto);
            return RedirectToAction("List", "Menu");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.menu = "active";

            var value = await _menuService.GetByIdMenuAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMenuDto updateMenuDto)
        {
            ViewBag.menu = "active";

            await _menuService.UpdateMenuAsync(updateMenuDto);
            return RedirectToAction("List", "Menu");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _menuService.DeleteMenuAsync(id);
            return RedirectToAction("List", "Menu");
        }
    }
}