using Microsoft.AspNet.Identity;
using SkateShop.Data;
using SkateShop.Models;
using SkateShop.Models.Payment;
using SkateShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkateShop.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PaymentService(userId);
            var model = service.GetPayment();

            return View(model);
        }

        // GET: Create Payment
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publish Payment to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePaymentService();

            if (service.PaymentCreate(model))
            {
                TempData["SaveResult"] = "Your payment was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Payment could not be created.");
            return View(model);
        }

        private PaymentService CreatePaymentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PaymentService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePaymentService();
            var model = svc.GetPaymentByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePaymentService();
            var detail = service.GetPaymentByID(id);
            var model =
                new PaymentEdit
                {
                    PaymentID = detail.PaymentID,
                    BillingAddress = detail.BillingAddress,
                    CardHolderName = detail.CardHolderName,
                    CardNumber = detail.CardNumber,
                    ExpirationMonth = detail.ExpirationMonth,
                    ExpirationYear = detail.ExpirationYear,
                    UserEmail = detail.UserEmail
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaymentEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.PaymentID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreatePaymentService();

            if (service.UpdatePayment(model))
            {
                TempData["Save Result"] = "Your payment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your payment could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePaymentService();
            var model = svc.DeletePayment(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePaymentService();

            service.DeletePayment(id);

            TempData["Save Result"] = "Your payment was deleted.";

            return RedirectToAction("Index");
        }
    }
}