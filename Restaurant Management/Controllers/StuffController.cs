﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Management.Context;
using Restaurant_Management.Models;

namespace Restaurant_Management.Controllers
{
    public class StuffController : Controller
    {
        Resturant db = new Resturant();
        // GET: Stuff
        public ActionResult Index()
        {
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Staff staff)
        {
            var usr = db.Staff.Single(u => u.UserName == staff.UserName && u.Password == staff.Password);
            var st = usr.Role;
            if (usr != null)
            {
                Session["UserId"] = usr.StaffId.ToString();
                Session["UserName"] = usr.UserName.ToString();
                if (st == 1)
                    return RedirectToAction("LoggedIn");
                if (st == 0)
                    return RedirectToAction("Employee");
                else
                    return HttpNotFound();
                //return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong..");
            }

            return View();
                
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Employee()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}