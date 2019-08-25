
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
            var cat = dt.GetCategories();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Create(Categories cat)
        {
            //Ask before you delete or change
            dt.InsertCategory(cat);
            
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }


        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = dt.GetCategories().Single(data => data.ID == id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Categories catg)
        {
                // TODO: Add update logic here
                dt.UpdateCategory(catg);
                return RedirectToAction("Index");
          
        }



        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var detail = dt.GetCategories().Single(data => data.ID == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }


        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = dt.GetCategories().Single(data => data.ID == id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Categories ct)
        {
            // TODO: Add update logic here
            dt.DeleteCategory(ct);
            return RedirectToAction("Index");
        }


        // GET: PersonalDetails/Delete/5
        
        //private HttpClient client = new HttpClient();

        //string url = "http://localhost:8009/";

        //public async Task<ActionResult> Index()
        //{
        //    List<Categories> catInfo = new List<Categories>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        HttpResponseMessage Res = await client.GetAsync("api/Values/GetCatagory");

        //        //Checking the responce if is successful
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var CategoryResponce = Res.Content.ReadAsStringAsync().Result;

        //            //Deserilizing the responce
        //            catInfo = JsonConvert.DeserializeObject<List<Categories>>(CategoryResponce);

        //        }
        //    }
        //    return View(catInfo);
        //}


        //Insert Category
        //[HttpPost]
        //[ActionName("Create")]
        //public async Task<ActionResult> Create(Categories catObj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            // Assuming the API is in the same web application. 
        //            client.BaseAddress = new Uri(url);
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Accept.Clear();

        //            UpdateModel(catObj);
        //            HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/InsertCatagory", catObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();

        //}

        //Update Category



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
        //            Categories CategoryObj = new Categories();
        //            UpdateModel(CategoryObj);
        //            HttpResponseMessage response = await client.PutAsJsonAsync("api/Values/UpdateCategory", CategoryObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();

        //}





        //Details
        




        // GET: Category/Create

        //public ActionResult Create()
        //{
        //    return View();
           
        //}

       

       

       
        
    }
}
