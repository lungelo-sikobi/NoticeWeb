using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class TryController : Controller
    {
        // GET: Try
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Categories d)
        {
            DataAcess dt = new DataAcess();
            dt.InsertCategory(d);
            return RedirectToAction("Index");
            
        }
    }
}