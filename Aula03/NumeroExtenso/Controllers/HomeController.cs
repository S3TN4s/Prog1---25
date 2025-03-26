using Microsoft.AspNetCore.Mvc;
using NumeroExtenso.Models;
using System.Diagnostics;

namespace NumeroExtenso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult NumeroExtenso()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NumeroExtenso(int number)
        {
            var model = new NumberConversion { Number = number };
            var extenso = model.ToExtenso();
            ViewData["Extenso"] = extenso;

            return View("NumeroExtenso"); // Retorna a mesma view para exibir o resultado
        }

        public IActionResult Index()
        {
            return View("NumeroExtenso");
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
    }
}
