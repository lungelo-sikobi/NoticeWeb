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
       
        private HttpClient client = new HttpClient();

        string url = "http://localhost:8009/";

        public async Task<ActionResult> Index()
        {
            List<Admin> AdminInfo = new List<Admin>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                HttpResponseMessage Res = await client.GetAsync("api/Values/GetAdmins");

                //Checking the responce if is successful
                if (Res.IsSuccessStatusCode)
                {
                    var AdmninResponce = Res.Content.ReadAsStringAsync().Result;

                    //Deserilizing the responce
                    AdminInfo = JsonConvert.DeserializeObject<List<Admin>>(AdmninResponce);

                }
            }
            return View(AdminInfo);
        }


        //Insert Admin
        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    // Assuming the API is in the same web application. 
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    Admin AdminObj = new Admin();
                    UpdateModel(AdminObj);
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/InsertAdmin", AdminObj);

                    if (response.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();

        }


        //Update Admin
        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> Edit()
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    Admin AdminsObj = new Admin();
                    UpdateModel(AdminsObj);
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/Values/UpdateAdmin", AdminsObj);

                    if (response.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();

        }




        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
