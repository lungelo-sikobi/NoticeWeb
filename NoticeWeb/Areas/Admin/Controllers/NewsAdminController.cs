using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Areas.Admin.Controllers
{
    public class NewsAdminController : Controller
    {
        // GET: Admin/NewsAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}