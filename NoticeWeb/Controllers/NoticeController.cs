using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            var list = dt.GetNoticesData();
            return View(list);
        }
        public ActionResult ViewNotice()
        {
            var list = dt.GetNoticesData();
            return View(list);
        }
        public ActionResult ViewCategory()
        {
            var list = dt.GetCategories();
            return View(list);
        }
        public ActionResult ViewAdmins()
        {
            var list = dt.GetAdmins();
            return View(list);
        }

        public ActionResult FlashScreen()
        {
            var list = dt.GetNoticesData();
            return View(list);
        }

        [HttpPost]
        public ActionResult AddingNotice(aNotice collection)
        {
           
                return View();

        }

        [HttpPost]
        public ActionResult AddingCategory()
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
        [HttpPost]
        public ActionResult AddingAdmin(FormCollection collection)
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

        [HttpPost]
        public ActionResult EditNotice(int id, FormCollection collection)
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

        [HttpPost]
        public ActionResult CategoryEdit(int id, FormCollection collection)
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
        [HttpPost]
        public ActionResult AdminEdit(int id, FormCollection collection)
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
      
        // GET: Notice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notice/Create
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
        public ActionResult EditNotice(aNotice id)
        {
            return View();
        }
        public ActionResult NoticeDetails(aNotice id)
        {
            return View();
        }

        // GET: Notice/Edit/5
        public ActionResult EditCategory(Categories id)
        {
          
            return View();
        }

        // POST: Notice/Edit/5
        [HttpPost]
        public ActionResult EditCategory(Categories id, FormCollection collection)
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

        // GET: Notice/Edit/5
        public ActionResult EditNotice(aNotice id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditNotice(aNotice id, FormCollection collection)
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

        // GET: Notice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notice/Delete/5
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
