using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    public class Result
    {
        public string Texto = string.Empty;
    }
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index",new Result());
        }

        //[HttpPost]
        //public IActionResult Index(string texto)
        //{
        //    Result resultado = new();
        //    resultado.Texto = texto.ToUpper();

        //    return View("Index", resultado);
        //}

        [HttpPost]
        public IActionResult Index(string texto)
        {

            Result resultado = new();
            resultado.Texto = texto.ToUpper();
            resultado.Texto = CeasarCipher(resultado.Texto);
            return View("Index", resultado);
        }

        public string CeasarCipher(string texto) 
        {
            int chave = 1;
            string[] alfabeto = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
            char[] c = texto.ToCharArray();
            //[C,A,S,A]
            for (int i = 0; i < c.length; i++)
            {
               for (int j = 0; j < alfabeto.length; j++)
               {
                   if (c[i] == alfabeto[j])
                   {
                       c[i] = alfabeto[j + chave];
                       
                   }
               }
            }
            c.ToString();
            Console.WriteLine(c);

        }
    }
}
