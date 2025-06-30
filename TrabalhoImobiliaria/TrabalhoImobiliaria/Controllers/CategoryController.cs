using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace TrabalhoImobiliaria.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly CategoryRepository _categoryRepository;

        public CategoryController(IWebHostEnvironment environment)
        {
            this._environment = environment;
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categorias = _categoryRepository.RetrieveAll();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category categoria = new Category();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Create(Category categoria)
        {
            _categoryRepository.Save(categoria);

            List<Category> categorias =
                _categoryRepository.RetrieveAll();

            return View("Index", categorias);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _categoryRepository.DeleteById(id);
            var imoveis = _categoryRepository.RetrieveAll();
            return View("Index", imoveis);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Category categoria = _categoryRepository.Retrieve(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Update(Category categoria)
        {
            _categoryRepository.Update(categoria);
            var categorias = _categoryRepository.RetrieveAll();
            return View("Index", categorias);
        }
    }
}
