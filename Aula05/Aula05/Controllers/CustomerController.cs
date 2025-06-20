﻿using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;
using System.IO;

namespace Aula05.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private CustomerRepository _customerRepository;

        public CustomerController(
            IWebHostEnvironment environment
        )
        {
            _customerRepository = new CustomerRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View("Index", customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent +=
                    String.Format("{0:5}", c.Id) +
                    String.Format("{0:5}", c.Name) +
                    String.Format("{0:64}", c.HomeAdress!.Id) +
                    String.Format("{0:5}", c.HomeAdress!.City) +
                    String.Format("{0:32}", c.HomeAdress!.State) +
                    String.Format("{0:2}", c.HomeAdress!.Country) +
                    String.Format("{0:32}", c.HomeAdress!.Street1) +
                    String.Format("{0:64}", c.HomeAdress!.Street2) +
                    String.Format("{0:64}", c.HomeAdress!.PostalCode) +
                    String.Format("{0:9}", c.HomeAdress!.AdressType) ;
            }

            SaveFile(fileContent, "DelimitadedFile.txt");

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            Customer customer = _customerRepository.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);

        }

        [HttpGet]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            if (
                _customerRepository.DeleteById(id.Value))
                return NotFound();


            return RedirectToAction("Index");
        }

        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(
                environment.WebRootPath,
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

                if (!System.IO.File.Exists(filepath))
                {
                    using (StreamWriter sw = System.IO.File.CreateText(filepath))
                    {
                        sw.Write(content);
                    }

                }
            }

            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
                //throw ioEx;
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

