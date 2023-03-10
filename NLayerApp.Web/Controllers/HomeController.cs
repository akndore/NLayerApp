using Microsoft.AspNetCore.Mvc;
using NLayerApp.Web.Models;
using System.Diagnostics;
using NLayerApp.Core.DTOs;

namespace NLayerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorModel errorModel)
        {
            return View(errorModel);
        }
    }
}