using Notice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class FlashScreenController : Controller
    {
        // GET: FlashScreen
        DataAcess dt = new DataAcess();
        public ActionResult Flashing()
        {
            var flash = dt.GetNoticeTitle();
            return View(flash);
        }

        // GET: FlashScreen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlashScreen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlashScreen/Create
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

        // GET: FlashScreen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlashScreen/Edit/5
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

        // GET: FlashScreen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlashScreen/Delete/5
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
