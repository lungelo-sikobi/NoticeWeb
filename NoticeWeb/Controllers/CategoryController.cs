﻿using Notice.DAL;
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

namespace NoticeWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            var list = dt.GetCategories();
            return View(list);
        }


        //Code for the API
        //Get Category
        private HttpClient client = new HttpClient();

        string url = "http://localhost:8009/";

        public async Task<ActionResult> IndexC()
        {
            List<Categories> catInfo = new List<Categories>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                HttpResponseMessage Res = await client.GetAsync("api/Values/GetCategories");

                //Checking the responce if is successful
                if(Res.IsSuccessStatusCode)
                {
                    var CategoryResponce = Res.Content.ReadAsStringAsync().Result;

                    //Deserilizing the responce
                    catInfo = JsonConvert.DeserializeObject<List<Categories>>(CategoryResponce);

                }
            }
            return View(catInfo);
        }


        //Insert Category
        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> CreateCategory()
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    // Assuming the API is in the same web application. 
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    Categories catObj = new Categories();
                    UpdateModel(catObj);
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/InsertCategory", catObj);

                    if (response.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();

        }

        //Update Category
        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditCategory()
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    Categories CategoryObj = new Categories();
                    UpdateModel(CategoryObj);
                    HttpResponseMessage response = await client.PutAsJsonAsync("api/Values/UpdateCategory", CategoryObj);

                    if (response.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();

        }





        //Details
        public async Task<ActionResult> DetailsCategory(int id)
        {
            return View();
        }




        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create

        public ActionResult Create()
        {
            return View();
           
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Categories obj)
        {
            try
            {
                DataAcess dt = new DataAcess();
                dt.InsertCategory(obj);
                return RedirectToAction("Index");
              
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
