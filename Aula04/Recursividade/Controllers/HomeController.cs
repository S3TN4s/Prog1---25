using System.Diagnostics;
using Aula04Recursividade.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula04Recursividade.Controllers
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public string PrintNaturalFor(int n = 10)
        {
            string retorno = string.Empty;
            int i = 1;

            while(i <= n){
                
                retorno += $" {i} ";

                i++;
            }

            return retorno;

        }

        //1)
        [HttpGet]
        public string PrintNaturalRecursion(int count = 10)
        {
            string retorno = string.Empty;

            retorno = NaturalNumberRecursion(1, count);


            return retorno;
        }


        [HttpGet]
        public string NaturalNumberRecursion(int n, int count)
        {
            string ret = string.Empty;

            //Caso Base: Se o contador for < que 1 
            if (count <= 1) {
                return $" {n} ";
            }

            ret += $" {n} ";
            count--;

            ret += NaturalNumberRecursion(n+1,count);

            return ret;
        }

        //2)
        [HttpGet]

        [HttpGet]
        public int NumberSumRecursion(int n1)
        {
            int sum = 0;
            int indice = 0;

            if(indice <= n )
            {
                return sum;
            }

            indice++;

            sum += NumberSumRecursion(indice + 1);

            return sum;
        }

        //3)       
        [HttpGet]
        public int StringLengthRecursion(string text, int indice)
        {
            string retorno = string.Empty;
            indice = 1;

            if(indice == text.Length)
            {
                return indice;
            }

            indice += StringLengthRecursion(text,indice);

            return indice;
        }

        //4)
        [HttpGet]
        public bool IsStringPalindromo(string text1, int indice1 = 0)
        {
            string palavraFinal = string.Empty;

            char[] textArray = text1.ToCharArray();
            if (indice1 == 0)
            {
                indice1 = text1.Length + 1;
            }

            if (palavraFinal == textArray.ToString())
            {
                return true;
            }
            indice1--;
            palavraFinal += IsStringPalindromo(text1,indice1);

            return false;

        }

    }
}
