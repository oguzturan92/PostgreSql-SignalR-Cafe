using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlassyCafePostgreSql.Dtos.AdminDtos;
using KlassyCafePostgreSql.Services.CategoryServices;
using KlassyCafePostgreSql.Services.ProductServices;
using KlassyCafePostgreSql.Services.ReservationServices;
using KlassyCafePostgreSql.Services.TableServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITableService _tableService;
        private readonly IReservationService _reservationService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminController(ITableService tableService, IReservationService reservationService, IProductService productService, ICategoryService categoryService)
        {
            _tableService = tableService;
            _reservationService = reservationService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.admin = "active";

            var dto = new AdminListDto()
            {
                TableCount = _tableService.TableIsFullCount(),
                ReservationCount = _reservationService.ReservationCount(),
                ProductCount = _productService.ProductCount(),
                CategoryCount = _categoryService.CategoryCount()
            };
            
            return View(dto);
        }
    }
}