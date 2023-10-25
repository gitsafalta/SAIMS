using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using SAIMS.Application.Models;
using SAIMS.Presentation.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SAIMS.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SalesSummaryReport()
        {
            return View();
        }

        public IActionResult InventoryStatusReport()
        {
            return View();
        }

        public IActionResult DiscountUsageReport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}