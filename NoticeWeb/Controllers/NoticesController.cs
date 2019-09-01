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
using System.Configuration;
using System.Data.SqlClient;




namespace NoticeWeb.Controllers
{
    public class NoticesController : Controller
    {
        DataAcess dt = new DataAcess();
        string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        //Get Notice
        //m
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var notList = dt.GetNoticesData();
                return View(notList);
            }
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                ViewBag.CategoryID = ToSelectList();
                return View();
            }
         
            return RedirectToAction("Index", "Home");
        }
        //Create Notice
        [HttpPost]
        public ActionResult Create(aNotice not, HttpPostedFileBase postedFile)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                not.AdminID = (int)Session["AdminID"];
                if (dt.InsertNotice(not) == 1)
                {
                  try { 
                        byte[] bytes;
                        using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                        {
                            bytes = br.ReadBytes(postedFile.ContentLength);
                        }
                        string constr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string query = "INSERT INTO Files(Name,ContentType,Data,NoticeID) VALUES(@Name, @ContentType, @Data,(Select max(NoticeID)from Notices))";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@Name", Path.GetFileName(postedFile.FileName));
                                cmd.Parameters.AddWithValue("@ContentType", postedFile.ContentType);
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                return RedirectToAction("Index");
                            }

                        }
                    }
                    catch
                    {

                    }

                }
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        public SelectList ToSelectList()
        {
           
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Categories row in dt.GetCategories())
            {
                list.Add(new SelectListItem()
                {
                    Text = row.Name.ToString(),
                    Value = row.ID.ToString()
                });
            }

            return new SelectList(list, "Value","Text");
        }
        [HttpPost]
        public ActionResult MultipleFiles(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            string constr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO Files(Name,ContentType,Data) VALUES(@Name, @ContentType, @Data)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Name", Path.GetFileName(postedFile.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", postedFile.ContentType);
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View(GetFiles());

        }


        // GET: Notice/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var notice = dt.GetNoticesData().Single(data => data.NoticeID == id);
                return View(notice);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Notice/Edit/5
        [HttpPost]
        public ActionResult Edit(aNotice not)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                // TODO: Add update logic here
                dt.UpdateNotice(not);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");

        }


        // GET: Notices/Details/5
        public ActionResult Details(int id)
        {
           
            
                var detail = dt.GetNoticesData().Single(data => data.NoticeID == id);
                if (detail == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Data = detail;
                return View(GetFiles(id));
           

        }
        public ActionResult Attachement(int id)
        {


            var detail = dt.GetNoticesData().Single(data => data.NoticeID == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Data = detail;
            return View(GetFiles(id));


        }
        private static List<FileModel> GetFiles()
        {
            List<FileModel> files = new List<FileModel>();
            string constr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Files where NoticeID is null"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            files.Add(new FileModel
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return files;
        }
        private static List<FileModel> GetFiles(int id)
        {
            List<FileModel> files = new List<FileModel>();
            string constr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Name FROM Files where NoticeID=" + id))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            files.Add(new FileModel
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return files;
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Name, Data, ContentType FROM Files WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", fileId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        fileName = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }

            return File(bytes, contentType, fileName);
        }

        //Delete Notice
        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if((bool)Session["Super"] == true)
            {
                var notice = dt.GetNoticesData().Single(data => data.NoticeID == id);
                return View(notice);
            }
            return RedirectToAction("Index", "Home");
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
            else if((bool)Session["Super"] == true)
            {
                dt.DeleteNotice(not);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }




    }
}

