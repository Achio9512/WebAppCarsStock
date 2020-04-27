using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAppCarsStock.Models;

namespace WebAppCarsStock.Controllers
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

        [HttpPost]
        [Route("/GetCarsDetails")]
        public IActionResult GetCarsDetails(CarsDetails cars)
        {
            Console.WriteLine(cars);
            return Json(new { success = true });
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public T GetContentFromJson<T>(string path)
        {
            var fullPath = $".json";
            var jsonFile = JsonConvert.DeserializeObject<T>(fullPath);
            return jsonFile;
        }
    }
}
