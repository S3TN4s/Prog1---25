using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System;
using TrabalhoImobiliaria.ViewModels;

namespace TrabalhoImobiliaria.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly PropertyRepository _propertyRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly AddressRepository _addressRepository;

        public PropertyController(IWebHostEnvironment environment)
        {
            this._environment = environment;
            _propertyRepository = new PropertyRepository();
            _categoryRepository = new CategoryRepository();
            _addressRepository = new AddressRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Property> imoveis = _propertyRepository.RetrieveAll();

            return View(imoveis);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PropertyViewModel()
            {
                Categories = _categoryRepository.RetrieveAll(),
                Property = new Property(),
                Addresses = _addressRepository.RetrieveAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Property imovel)
        {
            // Recupera a categoria selecionada
            if (imovel.CategoriaId > 0)
            {
                imovel.Categoria = _categoryRepository.Retrieve(imovel.CategoriaId);
            }
            if (imovel.AddressId > 0)
            {
                imovel.Address = _addressRepository.Retrieve(imovel.AddressId);
            }

            _propertyRepository.Save(imovel);

            List<Property> imoveis = _propertyRepository.RetrieveAll();

            return View("Index", imoveis);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _propertyRepository.DeleteById(id);
            var imoveis = _propertyRepository.RetrieveAll();
            return View("Index", imoveis);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var property = _propertyRepository.Retrieve(id);
            var viewModel = new PropertyViewModel
            {
                Property = property,
                Categories = _categoryRepository.RetrieveAll(),
                Addresses = _addressRepository.RetrieveAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(PropertyViewModel model)
        {
            // Atualiza as referências de Categoria e Endereço
            if (model.Property is not null)
            {
                if (model.Property.CategoriaId > 0)
                    model.Property.Categoria = _categoryRepository.Retrieve(model.Property.CategoriaId);

                if (model.Property.AddressId > 0)
                    model.Property.Address = _addressRepository.Retrieve(model.Property.AddressId);

                _propertyRepository.Update(model.Property);
            }

            var properties = _propertyRepository.RetrieveAll();
            return View("Index", properties);
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Property c in PropertyData.Imoveis)
            {
                fileContent +=
                    $"{c.Id};{c.NroQuartos};{c.NroVagas};{c.NroBanheiros};{c.Nome};{c.Descricao};{c.Categoria?.Name};{c.Address?.Country};{c.Address?.State};{c.Address?.City};{c.Address?.PostalCode};{c.Address?.Number}\n";
            }

            SaveFile(fileContent, "DelimitatedFile.txt");

            return View();
        }

        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(
                _environment.WebRootPath,
                "TextFiles"
            );

            try
            {

                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(
                    path,
                    fileName
                );

                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(content);
                }
            }
            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
            }

            return ret;
        }
    }
}
