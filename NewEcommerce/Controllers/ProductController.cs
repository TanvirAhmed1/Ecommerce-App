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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace NewEcommerce.Controllers
{
    public class ProductController : Controller
    {
        IProductManager productManager;
        ICatagoryManager catagoryManager;
        public ProductController(IProductManager _productManager, ICatagoryManager _catagoryManager)
        {
            productManager = _productManager;
            catagoryManager = _catagoryManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ProductCreateViewModel product = new ProductCreateViewModel();
            product.CatagoryItem = catagoryManager.GetAll()
                                                   .Select(c => new SelectListItem()
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel entity, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = entity.Name,
                    Quantity = entity.Quantity,
                    Code = entity.Code,
                    Price = entity.Price,
                    CategoryId = entity.CategoryId
                };

                if (Image.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        product.Image = stream.ToArray();
                    }
                }

                bool isSave = productManager.Add(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }

        public IActionResult List()
        {
            ICollection<Product> products = productManager.GetAll();
            return View(products);
        }

        public IActionResult Edit(int? id)
        {
            if (id != null && id > 0)
            {
                Product product = productManager.GetById(id);
                if (id != null)
                {
                    return View(product);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            bool isSave = productManager.Update(product);
            if (isSave)
            {
                return RedirectToAction("List");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                Product product = productManager.GetById(id);
                bool isSave = productManager.Remove(product);
                if (isSave)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}