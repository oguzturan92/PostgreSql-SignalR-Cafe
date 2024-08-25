using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.ViewComponents.Product
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public ProductViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetCategoriesAndProducts();
            return View(values);
        }  
    }
}