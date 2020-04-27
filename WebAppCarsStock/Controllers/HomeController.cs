using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using WebAppCarsStock.ListImplementation;
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

        [HttpGet]
        [Route("/GetCarsDetails")]
        public IActionResult GetCarsDetails(CarsDetails cars)
        {
            var linkedListManual = GetLinkedList(cars.ListAgent);
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

        private LinkedList GetLinkedList(ListOfAgents agents)
        {
            LinkedList listFromScrath = new LinkedList();
            agents = GetContentFromJson<ListOfAgents>();
            foreach (var t in agents.Agent)
            {
                listFromScrath.AddFirst(t);
            }
            return listFromScrath;
        }

        public ListOfAgents GetContentFromJson<T>()
        {
            var fullPath = $"JsonFile/Agent.json";
            var jsonFile = JsonConvert.DeserializeObject<ListOfAgents>(System.IO.File.ReadAllText(fullPath));
            return jsonFile;
        }
    }
}
