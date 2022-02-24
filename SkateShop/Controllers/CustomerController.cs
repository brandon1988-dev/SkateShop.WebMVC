using Microsoft.AspNet.Identity;
using SkateShop.Data;
using SkateShop.Models.Customer;
using SkateShop.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SkateShop.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();

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
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.CustomerCreate(model))
            {
                TempData["SaveResult"] = "Your customer was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer could not be created.");
            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerByID(id);
            var model =
                new CustomerEdit
                {
                    CustomerID = detail.CustomerID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    PaymentType = detail.PaymentType,
                    FavoriteID = detail.FavoriteID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.CustomerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["Save Result"] = "Your customer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your customer could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["Save Result"] = "Your customer was deleted.";

            return RedirectToAction("Index");
        }
    }
}