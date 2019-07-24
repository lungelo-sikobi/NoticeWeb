using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        string url = "";

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
