using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.CategoryDtos;
using KlassyCafePostgreSql.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.category = "active";

            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.category = "active";

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            ViewBag.category = "active";

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("List", "Category");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.category = "active";

            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            ViewBag.category = "active";

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return RedirectToAction("List", "Category");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("List", "Category");
        }
    }
}