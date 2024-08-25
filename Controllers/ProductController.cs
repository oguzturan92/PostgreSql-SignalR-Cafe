using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.ProductDtos;
using KlassyCafePostgreSql.Services.CategoryServices;
using KlassyCafePostgreSql.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> List(int page = 1)
        {
            ViewBag.product = "active";

            const int pageSize = 10;
            
            var productCount = await _productService.GetAllProductCountAsync();
            ViewBag.pageCount = (int)Math.Ceiling((decimal)productCount/pageSize);
            var values = await _productService.GetAllProductAsync(pageSize, page);
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.product = "active";

            ViewBag.categories = await _categoryService.GetAllCategoryAsync();
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            ViewBag.product = "active";

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("List", "Product");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.product = "active";

            ViewBag.categories = await _categoryService.GetAllCategoryAsync();

            var value = await _productService.GetByIdProductAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            ViewBag.product = "active";

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("List", "Product");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("List", "Product");
        }
    }
}