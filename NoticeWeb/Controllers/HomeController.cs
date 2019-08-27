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
                return RedirectToAction("Index", "Notices",new { AdminID = Session["AdminID"].ToString()});
            }
            else
            {
                var notList = dt.GetNoticesData();
                ViewBag.Data = notList;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Index(Admin Z)
        {
            try
            {

                var userLoggedIn = dt.GetAdmins().SingleOrDefault(x => x.Email == Z.Email && x.Password == Z.Password);

                if (userLoggedIn != null)
                {
                    Session["AdminID"] = userLoggedIn.AdminID;
                    Session["user"] = userLoggedIn.Name + " " + userLoggedIn.Surname;
                    return RedirectToAction("Index", "Notices");
                }
                TempData["msg"] = "<script>alert('Nice try!!! Only Admins are allowed to log in');</script>";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var detail = dt.GetNoticesData().Single(data => data.NoticeID == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
           
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