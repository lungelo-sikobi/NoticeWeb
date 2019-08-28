using Newtonsoft.Json;
using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        //m
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var notList = dt.GetNoticesData();
                return View(notList);
            }
            
        }
        
        [HttpGet]
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
        //Create Notice
        [HttpPost]
        public ActionResult Create(aNotice not,HttpPostedFileBase imgfile)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                not.AdminID = (int)Session["AdminID"];
                dt.InsertNotice(not);
             
                return View();
            }
        }

        public string uploadFile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();

            if(file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if(extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".docx") || extension.ToLower().Equals(".pdf") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/192.168.137.1,1433/Notices/Attachment"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/192.168.137.1,1433/Notices/Attachment" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg,jpeg,docx,pdf or png formats are acceptable');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file');</script>");
            }

            return path;
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
                var notice = dt.GetNoticesData().Single(data => data.NoticeID == id);
                return View(notice);
            }
        }

        // POST: Notice/Edit/5
        [HttpPost]
        public ActionResult Edit(aNotice not)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // TODO: Add update logic here
                dt.UpdateNotice(not);
                return RedirectToAction("Index");
            }

        }

        // GET: Notices/Details/5
        public ActionResult Details(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var detail = dt.GetNoticesData().Single(data => data.NoticeID == id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                return View(detail);
            }
        }

        //Delete Notice
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var notice = dt.GetNoticesData().Single(data => data.NoticeID == id);
                return View(notice);
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(aNotice not)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.DeleteNotice(not);
                return RedirectToAction("Index");
            }
        }


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



        

        // GET: Notices/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Notices/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        

    }
}
