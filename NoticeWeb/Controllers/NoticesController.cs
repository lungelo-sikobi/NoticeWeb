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
    public class NoticesController : Controller
    {
        DataAcess dt = new DataAcess();

        //Get Notice
        public ActionResult Index()
        {
            var notList = dt.GetNoticesData();
            return View();
        }

        //Create Notice
        [HttpPost]
        public ActionResult Create(aNotice not)
        {
            dt.InsertNotice(not);
            return View();
        }

        //Edit Notice
        public ActionResult Edit(int id)
        {
            aNotice notice = dt.GetNoticesData().Single(data => data.NoticeID == id);
            return View(notice);
        }

        //Delete Notice


        //private HttpClient client = new HttpClient();
        //string url = "http://localhost:8009/";
        //// GET: Notices
        //public async Task<ActionResult> Index()
        //{
        //    List<aNotice> NoticeInfo = new List<aNotice>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format
        //        HttpResponseMessage Res = await client.GetAsync("api/Values/GetNoticeData");

        //        //Checking the responce if is successful
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var NoticeResponce = Res.Content.ReadAsStringAsync().Result;

        //            //Deserilizing the responce
        //            NoticeInfo = JsonConvert.DeserializeObject<List<aNotice>>(NoticeResponce);

        //        }
        //    }
        //    return View(NoticeInfo);
        //}

        //Insert Notice
        //[HttpPost]
        //[ActionName("Create")]
        //public async Task<ActionResult> Create(aNotice NotObj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            // Assuming the API is in the same web application. 
        //            client.BaseAddress = new Uri(url);
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            //= new aNotice();
        //            UpdateModel(NotObj);
        //            HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/InsertNotice", NotObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();

        //}

        //Update Notice
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
        //            aNotice NoticesObj = new aNotice();
        //            UpdateModel(NoticesObj);
        //            HttpResponseMessage response = await client.PutAsJsonAsync("api/Values/UpdateNotice", NoticesObj);

        //            if (response.IsSuccessStatusCode == true)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return View();

        //}

        //Delete Notice
        //[HttpPost]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // Assuming the API is in the same web application. 
        //        client.BaseAddress = new Uri(url);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        HttpResponseMessage response = await client.PostAsJsonAsync("api/Values/DeleteNotice", id);

        //        if (response.IsSuccessStatusCode == true)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: Notices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        // POST: Notices/Create
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

        // GET: Notices/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Notices/Edit/5
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

        

        // POST: Notices/Delete/5
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
