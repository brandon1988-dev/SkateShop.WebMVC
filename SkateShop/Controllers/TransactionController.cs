using Microsoft.AspNet.Identity;
using SkateShop.Models.Transaction;
using SkateShop.Services;
using System;
using System.Web.Mvc;

namespace SkateShop.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            var model = service.GetTransactions();

            return View(model);
        }

        // GET: Create Transaction
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publish Customer to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateTransactionService();

            if (service.TransactionCreate(model))
            {
                TempData["SaveResult"] = "Your transaction was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be created.");
            return View(model);
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TransactionService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTransactionService();
            var detail = service.GetTransactionByID(id);
            var model =
                new TransactionEdit
                {
                    ProductID = detail.ProductID,
                    ItemCount = detail.ItemCount,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateTransactionService();

            if (service.UpdateTransaction(model))
            {
                TempData["Save Result"] = "Your transaction was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your transaction could not be updated.");
            return View(model);
        }
    }
}
