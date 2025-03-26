using Microsoft.AspNetCore.Mvc;
using NumeroExtenso.Models;

namespace NumeroExtenso.Controllers
{
    public class NumeroExtensoController : Controller
    {
        [HttpPost]
        public IActionResult NumeroExtenso(int number)
        {
            var model = new NumberConversion { Number = number };
            var extenso = model.ToExtenso();
            ViewData["Extenso"] = extenso;

            return View("NumeroExtenso"); // Retorna a mesma view para exibir o resultado
        }
    }
}