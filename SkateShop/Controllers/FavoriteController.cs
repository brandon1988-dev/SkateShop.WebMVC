using Microsoft.AspNet.Identity;
using SkateShop.Models.Favorite;
using SkateShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkateShop.Controllers
{
    public class FavoriteController : Controller
    {
        // GET: Favorites
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteService(userId);
            var model = service.GetFavorites();

            return View(model);
        }

        // GET: Create Favorite
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publish Favorite to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFavorite(FavoriteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFavoriteService();

            if (service.FavoriteCreate(model))
            {
                TempData["SaveResult"] = "Your favorite was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Favorite could not be created.");
            return View(model);
        }


        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoriteByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFavoriteService();
            var detail = service.GetFavoriteByID(id);
            var model =
                new FavoriteEdit
                {
                    FavoriteID = detail.FavoriteID,
                    ProductID = detail.ProductID,
                    ProductName = detail.ProductName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FavoriteEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.FavoriteID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateFavoriteService();

            if (service.UpdateFavorite(model))
            {
                TempData["Save Result"] = "Your favorite was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your favorite could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.DeleteFavorite(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFavoriteService();

            service.DeleteFavorite(id);

            TempData["Save Result"] = "Your product was deleted.";

            return RedirectToAction("Index");
        }
    }
}
