using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Database.Database;
using NewEcommerce.Models;
using Ecommerce.Models.EntityModels;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstractions;

namespace NewEcommerce.Controllers
{ 
    public class CustomerController : Controller
    {
        ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Customer customer = new Customer();
            customer.CustomerList = _customerManager.GetAll();

            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _customerManager.Add(customer);
                if (isSaved)
                {
                    return RedirectToAction("List", "Customer", null);
                }
            }

            return View();
        }


        public IActionResult List()
        {
            // get all customers from db 
            ICollection<Customer> customers = _customerManager.GetAll();



            //show the customers in VIEW
            return View(customers);
        }
        public IActionResult Edit(int? id)
        {
            
            if(id!= null && id > 0)
            {
                Customer existingCustomer = _customerManager.GetById(id);
                if(existingCustomer != null)
                {
                    return View(existingCustomer);
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            bool IsUpdated = _customerManager.Update(customer);
            if (IsUpdated)
            {
                return RedirectToAction("List");
            }
            return View(customer);
        }
        public IActionResult Delete(int? id)
        {
            if(id!=null && id > 0)
            {
                var customer = _customerManager.GetById(id);
                bool isSaved = _customerManager.Remove(customer);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }

    }
}