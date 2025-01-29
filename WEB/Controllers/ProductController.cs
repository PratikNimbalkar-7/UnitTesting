using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        // GET: Product
        public ActionResult Index()
        {
            var product = _productservice.GetAll();

            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productservice.Create(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            if (id > 0)
            {
                Product product = _productservice.GetById(id);

                if (product != null)
                {
                    return View(product);
                }

                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }


    }
}