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
using Ecommerce.Models.ResponseModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewEcommerce.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerManager _customerManager;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CustomerCreateViewModel customer = new CustomerCreateViewModel();
            customer.CustomerList = _customerManager.GetAll().Select(cust => _mapper.Map<CustomerResponseModel>(cust)).ToList();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer model)
        {

            if (ModelState.IsValid)
            {
                Customer customer = _mapper.Map<Customer>(model);
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

        //customer/edit/id
        public IActionResult Edit(int? id)
        {

            if (id != null && id > 0)
            {
                Customer existingCustomer = _customerManager.GetById(id);

                if (existingCustomer != null)
                {
                    return View(existingCustomer);
                }

            }

            return View();

        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            bool isUpdated = _customerManager.Update(customer);

            if (isUpdated)
            {
                return RedirectToAction("List");
            }

            return View(customer);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var customer = _customerManager.GetById(id);

                bool isdelete = _customerManager.Remove(customer);
                if (isdelete)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}