using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi.MVCUI.Areas.Admin.Controllers
{
    public class UrunYonetimController : Controller
    {
        Repository<Product> repository = new Repository<Product>();
        // GET: Admin/UrunYonetim
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View();
        }

        // GET: Admin/UrunYonetim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/UrunYonetim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UrunYonetim/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UrunYonetim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/UrunYonetim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/UrunYonetim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/UrunYonetim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
