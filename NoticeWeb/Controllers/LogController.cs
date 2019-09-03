using Notice.DAL;
using Notice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NoticeWeb.Controllers
{
    public class LogController : Controller
    {
        DataAcess dt = new DataAcess();
        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("index", "home");
           
        }

        // GET: Log/Details/5

        // GET: Log/Create
        public ActionResult Details(int id)
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
        public ActionResult ChangePassword(int id)
        {
            if (Session["AdminID"] != null)
            {
                    var detail = dt.ChangePasswordFor().Single(data => data.AdminID == id);
                    var name= dt.GetAdmins().Single(data => data.AdminID == (int)Session["AdminID"]);
                    ViewBag.name = name.Name + " " + name.Surname;
                if (detail == null)
                    {
                        return HttpNotFound();
                    }
                    return View(detail);
                
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Message: \n" + "Log in first" + " .');</script>");
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(Notice.Models.ChangePassword add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                add.AdminID = (int)Session["AdminID"];
                if(dt.UpdateAdminPassword(add)==1)
                {
                    
                    Response.Write(@"<script language='javascript'>alert('Message: \n" + "Your Password has been Successfully Updated Please Log in Again using it!" + " .');</script>");
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    return RedirectToAction("Index", "Notices");
                }
                Response.Write(@"<script language='javascript'>alert('Message: \n" + "Your Password has not been Successfully Updated!" + " .');</script>");
                return View();
            }
        }

        // POST: Log/Create
        
       

        // GET: Log/Edit/5
        public ActionResult Edit(int id)
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
        public ActionResult Edit(Admin add)
        {
            // TODO: Add update logic here
            if (Session["AdminID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                dt.UpdateAdminAccount(add);
                ViewBag.DataExists = true;
                return RedirectToAction("index","Notices");
            }
        }


        // GET: Log/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Log/Delete/5
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
