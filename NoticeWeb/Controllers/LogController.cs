using Notice.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class LogController : Controller
    {
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "home");
           
        }

        // GET: Log/Details/5

        // GET: Log/Create
        public ActionResult Details(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var detail = dt.GetAdmins().Single(data => data.AdminID == id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                return View(detail);
            }
        }


        // POST: Log/Create
        [HttpPost]
        public ActionResult Details(FormCollection collection)
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

        // GET: Log/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Log/Edit/5
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

        // GET: Log/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Log/Delete/5
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
