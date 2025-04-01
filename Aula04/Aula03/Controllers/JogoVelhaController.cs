using Microsoft.AspNetCore.Mvc;

namespace Aula03.Controllers
{
    public class JogoVelhaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(
            string A00, string A01, string A02,
            string A10, string A11, string A12,
            string A20, string A21, string A22
        )
        {
            string[,] matrixJV = new string[3, 3];
            matrixJV[0, 0] = A00;
            matrixJV[0, 1] = A01;
            matrixJV[0, 2] = A02;
            matrixJV[1, 0] = A10;
            matrixJV[1, 1] = A11;
            matrixJV[1, 2] = A12;
            matrixJV[2, 0] = A20;
            matrixJV[2, 1] = A21;
            matrixJV[2, 2] = A22;

            string Vencedor = string.Empty;
            //linha
            for (int i = 0; i < 3; i++){
                if (matrixJV[i, 0] == matrixJV[i, 1] && matrixJV[i, 1] == matrixJV[i, 2]){
                    Vencedor = matrixJV[i, 0]; 
                    break;
                }
            }
            //coluna
            if (Vencedor == null){
                for (int i = 0; i < 3; i++){
                    if (matrixJV[0, i] == matrixJV[1, i] && matrixJV[1, i] == matrixJV[2, i]){
                        Vencedor = matrixJV[0, i];  
                        break;
                    }
                }
            }
            //diagonal
            if (Vencedor == null && matrixJV[0, 0] == matrixJV[1, 1] && matrixJV[1, 1] == matrixJV[2, 2]){
                Vencedor = matrixJV[0, 0];  
            }

            if (Vencedor == null && matrixJV[0, 2] == matrixJV[1, 1] && matrixJV[1, 1] == matrixJV[2, 0]){
                Vencedor = matrixJV[0, 2];  
            }            

            return View("Index", $"Vencedor {Vencedor}");
        }
    }
}
