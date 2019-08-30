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
            else if ((bool)Session["Super"] == true)
            {
                var list = dt.GetAdmins();
                return View(list);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(Admin ad)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"]==true)
            {
                string i = dt.InsertAdmin(ad);
                TempData["CreateCat"] = "<script>alert('New Admin Created');</script>";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Create()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var exemploList = new SelectList(new[] { "IT" });
                ViewBag.Dep = exemploList;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        // GET: Notice/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var admin = dt.GetAdmins().Single(data => data.AdminID == id);
                return View(admin);
            }
            return RedirectToAction("Index","Home");
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
            else if((bool)Session["Super"] == true)
            {
                dt.UpdateAdmin(add);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var detail = dt.GetAdmins().Single(data => data.AdminID == id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                return View(detail);
            }
            return RedirectToAction("Index", "Home");
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var admin = dt.GetAdmins().Single(data => data.AdminID == id);
                return View(admin);
                
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(Admin add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                dt.DeleteAdmin(add);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }


       
    }
}
