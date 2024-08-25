using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.Dtos.TableDtos;
using KlassyCafePostgreSql.Services.TableServices;
using Microsoft.AspNetCore.Mvc;

namespace KlassyCafePostgreSql.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.table = "active";

            var values = await _tableService.GetAllTableAsync();
            return View(values);
        }

        public IActionResult Create()
        {
            ViewBag.table = "active";

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateTableDto createTableDto)
        {
            ViewBag.table = "active";

            await _tableService.CreateTableAsync(createTableDto);
            return RedirectToAction("List", "Table");
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.table = "active";

            var value = await _tableService.GetByIdTableAsync(id);
            return View(value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTableDto updateTableDto)
        {
            ViewBag.table = "active";

            await _tableService.UpdateTableAsync(updateTableDto);
            return RedirectToAction("List", "Table");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _tableService.DeleteTableAsync(id);
            return RedirectToAction("List", "Table");
        }

        public IActionResult Approval(int id)
        {
            ViewBag.table = "active";
            
            _tableService.ApprovalChange(id);
            return RedirectToAction("List", "Table");
        }
    }
}