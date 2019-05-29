using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class ENoticeController : Controller
    {
        // GET: ENotice
        public ActionResult Index()
        {
            return View();
        }

        // GET: ENotice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ENotice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ENotice/Create
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

        // GET: ENotice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ENotice/Edit/5
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

        // GET: ENotice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ENotice/Delete/5
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
