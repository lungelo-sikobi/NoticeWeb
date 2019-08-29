using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ChangePassword = Notice.Models.ChangePassword;

namespace NoticeWeb.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Password/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Password/Create
        [HttpPost]
        public ActionResult Create(ChangePassword collection)
        {
            try
            {
                if (Session["AdminID"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    collection.AdminID = (int)Session["AdminID"];
                    dt.UpdateAdminPassword(collection);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Password/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Password/Edit/5
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

        // GET: Password/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Password/Delete/5
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
