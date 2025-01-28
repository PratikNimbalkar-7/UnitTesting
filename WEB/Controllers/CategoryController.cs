using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class CategoryController : Controller
    {
        IcategoryService _categoryService;

        public CategoryController(IcategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var category = _categoryService.GetAll();

            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}