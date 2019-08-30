
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Notice.DAL;

namespace NoticeWeb.Controllers
{
    public class CategoryController : Controller
    {
        
        //Create Category
        //hh
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
                var cat = dt.GetCategories();
                return View(cat);
            }
        }

        [HttpPost]
        public ActionResult Create(Categories cat)
        {
            //Ask before you delete or change
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.InsertCategory(cat);
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
                return View();
            }
        }


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var category = dt.GetCategories().Single(data => data.ID == id);
                return View(category);
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Categories catg)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.UpdateCategory(catg);
                return RedirectToAction("Index");
            }
        }



        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var detail = dt.GetCategories().Single(data => data.ID == id);
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
                var category = dt.GetCategories().Single(data => data.ID == id);
                return View(category);
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Categories ct)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.DeleteCategory(ct);
                return RedirectToAction("Index");
            }
        }


        
       
        
    }
}
