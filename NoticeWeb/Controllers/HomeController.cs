﻿using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NoticeWeb.Controllers
{
    public class HomeController : Controller
    {
       
        DataAcess dt = new DataAcess();
        public ActionResult Index()
        {
            if (Session["AdminID"]!= null)
            {
                var user = dt.GetAdmins().SingleOrDefault(x => x.AdminID == (int)Session["AdminID"]);
               
                if (user.SuperAdmin == true)
                {
                    var list = dt.GetNoticesData();
                    ViewBag.Data = list;
                    return RedirectToAction("Index", "Notices");
                }
                if (user.DepartID != null)
                {
                    return RedirectToAction("Index", "DepartmentAdmin");
                }
                else
                {
                    Session["AdminID"] = user.AdminID;
                    Session["user"] = user.Name + " " + user.Surname;
                    Session["Super"] = user.SuperAdmin;
                    Session["CategoryID"] = user.CategoryID;
                    return RedirectToAction("Index", "CategoryAdmin");
                }
            }
            else
            {
                var list = dt.GetNoticesData();
                ViewBag.Data = list;
                return View();
            }
            
           

        }
        //public ActionResult Filter(String Search)
        //{
        //    if (Session["AdminID"] != null)
        //    {
        //        return RedirectToAction("Index", "Notices", new { AdminID = Session["AdminID"].ToString() });
        //    }
        //    else
        //    {
        //        var list = dt.GetNoticesData();
        //        if (!String.IsNullOrEmpty(Search))
        //        {
        //           // list = list.Where(x => x.Title.Contains(Search));
        //        }
        //        ViewBag.Data = list;
        //        return View();
        //    }

        //}
        public string Limit(string input, int max)
        {
            if (!String.IsNullOrEmpty(input) && input.Length > max)
            {
                return input.Substring(0, max);
            }
            return input;
        }
        [HttpPost]
        public ActionResult Index(Admin Z)
        {

            try { 
                var user = dt.GetAdmins().SingleOrDefault(x => x.Email == Z.Email && x.Password.ToString().Equals(Z.Password.GetHashCode().ToString()));

                if (user != null)
                {


                    if (user.LoggedOnce == false)
                    {
                        Session["AdminID"] = user.AdminID;
                        Session["user"] = user.Name + " " + user.Surname;
                      
                        return RedirectToAction("ChangePassword", "Log", new { id = Session["AdminID"] });
                    }

                    else
                    {
                        if (user.SuperAdmin==true)
                        {
                            Session["AdminID"] = user.AdminID;
                            Session["user"] = user.Name + " " + user.Surname;
                            Session["Super"] = user.SuperAdmin;
                            return RedirectToAction("Index", "Notices");
                        }
                        if (user.DepartID != null)
                        {
                            Session["AdminID"] = user.AdminID;
                            Session["user"] = user.Name + " " + user.Surname;
                            Session["Super"] = user.SuperAdmin;
                            Session["DepartID"] = user.DepartID;
                            return RedirectToAction("Index", "DepartmentAdmin");

                           
                        }
                        else
                        {
                            Session["AdminID"] = user.AdminID;
                            Session["user"] = user.Name + " " + user.Surname;
                            Session["Super"] = user.SuperAdmin;
                            Session["CategoryID"] = user.CategoryID;
                            return RedirectToAction("Index", "CategoryAdmin");
                        }

                    }
                }
                TempData["msg"] = "<script>alert('Nice try!!! Only Admins are allowed to log in');</script>";
                return RedirectToAction("Index", "Home");
        }
            catch
            {
                var list = dt.GetNoticesData();
                 ViewBag.Data = list;
                return View("Index");
            }
}
    


        // GET: Home/Details/5
        public ActionResult Details(int key)
        {

            return RedirectToAction("Details", "Notices", new { id = key });

        }


        //Forgot password

        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ForgotPassword(string Email)
        //{
        //    //Verify email entered
        //    //Generate reset password link
        //    //send email
        //    string message = "";
        //    bool status = false;

            
        //   var account = dt.GetAdmins().Single(data => data.Email == Email);
           
        //   if(account != null)
        //    {
        //        //send link to reset password
        //        string resetCode = Guid.NewGuid().ToString();

        //    }
        //    else
        //    {
        //        message = "Account not found";
        //    }
        //        return View();
        //}


        // GET: Home/Create
        public ActionResult Create()
        {
         
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Admin Z)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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