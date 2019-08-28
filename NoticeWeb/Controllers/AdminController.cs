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


        //private HttpClient client = new HttpClient();

        //string url = "http://10.0.1.229:8009/";

        //public async Task<ActionResult> Index()
        //{
        //    List<Admin> AdminInfo = new List<Admin>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        HttpResponseMessage Res = await client.GetAsync("api/Values/GetAdmin");

        //        //Checking the responce if is successful
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var AdmninResponce = Res.Content.ReadAsStringAsync().Result;

        //            //Deserilizing the responce
        //            AdminInfo = JsonConvert.DeserializeObject<List<Admin>>(AdmninResponce);

        //        }
        //    }
        //    return View(AdminInfo);
        //}


        ////Insert Admin



        ////Update Admin
        //[HttpPost]
        //[ActionName("Edit")]
        //public async Task<ActionResult> Edit()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var client = new HttpClient())
        //        {

        //            client.BaseAddress = new Uri(url);
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            Admin AdminsObj = new Admin();
        //            UpdateModel(AdminsObj);
        //            HttpResponseMessage response = await client.PutAsJsonAsync("api/Values/UpdateAdmin", AdminsObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();

        //}




        
      



        // POST: Admin/Create
        //[HttpPost]
        //public async Task<ActionResult> Create(Admin AdminObj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            // Assuming the API is in the same web application. 
        //            client.BaseAddress = new Uri(url);
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            UpdateModel(AdminObj);
        //            HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/InsertAdmin", AdminObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();
        //}

        // GET: Admin/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Admin/Edit/5
      

       
    }
}
