
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
            else if((bool)Session["Super"] == true)
            {
                var cat = dt.GetCategories();
                return View(cat);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(Categories cat)
        {
            //Ask before you delete or change
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                dt.InsertCategory(cat);
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
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var category = dt.GetCategories().Single(data => data.ID == id);
                return View(category);
            }
            return RedirectToAction("Index", "Home");
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
            else if((bool)Session["Super"] == true)
            {
                dt.UpdateCategory(catg);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
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
