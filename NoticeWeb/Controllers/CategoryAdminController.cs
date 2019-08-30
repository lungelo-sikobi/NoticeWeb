using Notice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class CategoryAdminController : Controller
    {
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {

            var notList = dt.GetNoticesData();
            return View(notList);
           
        }

        // GET: CategoryAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryAdmin/Create
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

        // GET: CategoryAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryAdmin/Edit/5
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

        // GET: CategoryAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryAdmin/Delete/5
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
