using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace NewEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        ICatagoryManager _catagoryManager;
        public CategoryController(ICatagoryManager catagoryManager)
        {
            _catagoryManager = catagoryManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Catagory model)
        {

            if (ModelState.IsValid)
            {
                Catagory catagory = new Catagory();
                catagory.Id = model.Id;
                catagory.Name = model.Name;

                bool isSaved = _catagoryManager.Add(catagory);

                if (isSaved)
                {
                    return RedirectToAction("List", "Category", null);
                }

            }

            return View();
        }


        public IActionResult List()
        {
            // get all customers from db 

            ICollection<Catagory> catagories = _catagoryManager.GetAll();

            //show the customers in VIEW
            return View(catagories);
        }

        //customer/edit/id
        public IActionResult Edit(int? id)
        {

            if (id != null && id > 0)
            {
                Catagory existingCatagory = _catagoryManager.GetById(id);

                if (existingCatagory != null)
                {
                    return View(existingCatagory);
                }

            }

            return View();

        }

        [HttpPost]
        public IActionResult Edit(Catagory catagory)
        {
            bool isUpdated = _catagoryManager.Update(catagory);

            if (isUpdated)
            {
                return RedirectToAction("List");
            }

            return View(catagory);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null && id > 0)
            {
                var catagory = _catagoryManager.GetById(id);

                bool isdelete = _catagoryManager.Remove(catagory);
                if (isdelete)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}
