using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunYonetim6584.Entities;
using UrunYonetimi6584.BL;

namespace UrunYonetimi.MVCUI.Areas.Admin.Controllers
{
    public class SliderYonetimiController : Controller
    {
        Repository<Slide> repository = new Repository<Slide>();
        // GET: Admin/SliderYonetimi
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/SliderYonetimi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SliderYonetimi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SliderYonetimi/Create
        [HttpPost]
        public ActionResult Create(Slide collection, HttpPostedFileBase Image)
        {
            try
            {
                // TODO: Add insert logic here
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    collection.Image = Image.FileName;
                }
                repository.Add(collection);
                var sonuc = repository.Save();
                if (sonuc > 0)
                    return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }

        // GET: Admin/SliderYonetimi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/SliderYonetimi/Edit/5
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

        // GET: Admin/SliderYonetimi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SliderYonetimi/Delete/5
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
