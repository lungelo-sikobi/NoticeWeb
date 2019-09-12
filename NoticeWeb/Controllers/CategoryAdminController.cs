using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticeWeb.Controllers
{
    public class CategoryAdminController : Controller
    {
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            var notList = dt.GetCategoryNotices((int)Session["CategoryID"]);
            return View(notList);

        }

        // GET: CategoryAdmin/Details/5
        public ActionResult AdminAccount(int id)
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
        // GET: Notice/Edit/5
        public ActionResult EditAdminAccount(int id)
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
        public ActionResult EditAdminAccount(Admin add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else            {
                dt.UpdateAdmin(add);
                return RedirectToAction("Index");
            }
          
        }

        // GET: CategoryAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryAdmin/Create
        [HttpPost]
        public ActionResult Create(aNotice not, HttpPostedFileBase postedFile)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            {
                not.AdminID = (int)Session["AdminID"];
                not.CategoryID = Session["CategoryID"].ToString();
                if (dt.InsertNotice(not) == 1)
                {
                    try
                    {
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
                                return RedirectToAction("Success");
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


        // GET: CategoryAdmin/Edit/5
   
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
                not.CategoryID = (Session["CategoryID"]).ToString();
                dt.UpdateNotice(not);
                return RedirectToAction("Index");
            }
          

        }
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

        // POST: Notice/Edit/5
        [HttpPost]
        public ActionResult Delete(aNotice not)
        {
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                // TODO: Add update logic here
                dt.DeleteNotice(not);
                return RedirectToAction("Index");
            }
          

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

        private class MessageVM
        {
            public MessageVM()
            {
            }

            public string CssClassName { get; set; }
            public string Title { get; set; }
            public string Message { get; set; }
        }
    }
}
