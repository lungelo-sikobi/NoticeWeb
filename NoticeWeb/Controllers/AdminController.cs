using Newtonsoft.Json;
using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //c
        DataAcess dt = new DataAcess();
        
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var list = dt.GetAdmins();
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult Create(Admin ad)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string i = dt.InsertAdmin(ad);
                TempData["CreateCat"] = "<script>alert('New Admin Created');</script>";
                return RedirectToAction("Index");
            }
        }


        public ActionResult Create()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var exemploList = new SelectList(new[] { "IT" });
                ViewBag.Dep = exemploList;
                return View();
            }
        }


        // GET: Notice/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var admin = dt.GetAdmins().Single(data => data.AdminID == id);
                return View(admin);
            }
        }

        // POST: Notice/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.UpdateAdmin(add);
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Details/5
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


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var admin = dt.GetAdmins().Single(data => data.AdminID == id);
                return View(admin);
                
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.DeleteAdmin(add);
                return RedirectToAction("Index");
            }
        }


       
    }
}
