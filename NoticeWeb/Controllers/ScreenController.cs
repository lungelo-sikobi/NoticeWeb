using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class ScreenController : Controller
    {
        // GET: Screen
        public ActionResult Index()
        {
            return View();
        }

        // GET: Screen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Screen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Screen/Create
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

        // GET: Screen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Screen/Edit/5
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

        // GET: Screen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Screen/Delete/5
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
