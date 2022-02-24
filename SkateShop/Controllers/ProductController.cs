using Microsoft.AspNet.Identity;
using SkateShop.Models;
using SkateShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkateShop.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        // GET: Products
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();

            return View(model);
        }

        // GET: Create Customer
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publish Customer to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateProductService();

            if (service.ProductCreate(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");
            return View(model);
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductByID(id);
            var model =
                new ProductEdit
                {
                    ProductID = detail.ProductID,
                    ProductName = detail.ProductName,
                    AvailableStock = detail.AvailableStock,
                    Price = detail.Price
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ProductID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["Save Result"] = "Your product was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["Save Result"] = "Your product was deleted.";

            return RedirectToAction("Index");
        }
    }
}
