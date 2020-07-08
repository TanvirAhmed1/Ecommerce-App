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
    public class ProductController : Controller
    {
        IProductManager _productManager;
        ICatagoryManager _catagoryManager;
        IMapper _mapper;
        public ProductController(IProductManager productManager, IMapper mapper, ICatagoryManager catagoryManager)
        {
            _productManager = productManager;
            _catagoryManager = catagoryManager;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ProductCreateViewModel product = new ProductCreateViewModel();
            product.CustomerList = _productManager.GetAll().Select(c => _mapper.Map<ProductResponseModel>(c)).ToList();
            product.CatagoryItems = _catagoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _mapper.Map<Product>(model);

                bool isSaved = _productManager.Add(product);
                if (isSaved)
                {
                    return RedirectToAction("List", "Product", null);
                }
            }

            return View();
        }


        public IActionResult List()
        {
            // get all customers from db 
            ICollection<Product> products = _productManager.GetAll();



            //show the customers in VIEW
            return View(products);
        }
        public IActionResult Edit(int? id)
        {
            var model = new ProductEditViewModel();
            model.CatagoryItems = _catagoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
            if (id != null && id > 0)
            {
                Product existingProduct = _productManager.GetById(id);
                if (existingProduct != null)
                {
                    _mapper.Map<Product, ProductEditViewModel>(existingProduct, model);
                }
            }


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            bool IsUpdated = _productManager.Update(product);
            if (IsUpdated)
            {
                return RedirectToAction("List");
            }
            return View(product);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var product = _productManager.GetById(id);
                bool isSaved = _productManager.Remove(product);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }

    }
}