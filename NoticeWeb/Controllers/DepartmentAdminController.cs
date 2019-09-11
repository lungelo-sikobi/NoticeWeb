using Notice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class DepartmentAdminController : Controller
    {
      
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            var notList = dt.GetDepartmentNotices((int)Session["DepartID"]);
            return View(notList);

        }

        // GET: DepartmentAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentAdmin/Create
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

        // GET: DepartmentAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentAdmin/Edit/5
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

        // GET: DepartmentAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentAdmin/Delete/5
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
