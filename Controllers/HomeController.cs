using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KlassyCafePostgreSql.Models;

namespace KlassyCafePostgreSql.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}