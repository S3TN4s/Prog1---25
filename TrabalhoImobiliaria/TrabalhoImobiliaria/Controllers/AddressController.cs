using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace TrabalhoImobiliaria.Controllers
{
    public class AddressController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly AddressRepository _AddressRepository;

        public AddressController(IWebHostEnvironment environment)
        {
            this._environment = environment;
            _AddressRepository = new AddressRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Address> addresses = _AddressRepository.RetrieveAll();

            return View(addresses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Address address = new Address();

            return View(address);
        }

        [HttpPost]
        public IActionResult Create(Address address)
        {
            _AddressRepository.Save(address);

            List<Address> addresses =
                _AddressRepository.RetrieveAll();

            return View("Index", addresses);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _AddressRepository.DeleteById(id);
            var imoveis = _AddressRepository.RetrieveAll();
            return View("Index", imoveis);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Address categoria = _AddressRepository.Retrieve(id);

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Update(Address address)
        {
            _AddressRepository.Update(address);
            var addresses = _AddressRepository.RetrieveAll();
            return View("Index", addresses);
        }
    }
}
