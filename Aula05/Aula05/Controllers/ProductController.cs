using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products =
                _productRepository.RetrieveAll();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _productRepository.Save(p);

            List<Product> products =
                _productRepository.RetrieveAll();

            return View("Index", products);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
