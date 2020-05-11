using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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


        //UPDATE ADMIN PROFILE GET

        public ActionResult UpdateAdminProfile(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Staff stuff = db.Staff.Find(id);
            if (stuff == null)
                return HttpNotFound();
            return View(stuff);
        }
        // POST: AdminUpdate
        [HttpPost]
        public ActionResult UpdateAdminProfile(Staff stuff)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(stuff).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("LoggedIn");
                }
                return View(stuff);
            }
            catch
            {
                return View();
            }
        }
        //////////////////////////LIST EMPLOYEES///////////////////////////////////
        public ActionResult ListEmployees()
        {
            return View(db.Staff.ToList());
        }

        /////////// Employee Detail//////////////////
        public ActionResult EmployeeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff Employee = db.Staff.Find(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        ///////////////SEARCH FOR EMPLOYEE///////////////
        public ActionResult SearchEmployee(string search)
        {
            return View(db.Staff.Where(x => x.UserName.Contains(search)|| search == null).ToList());
           
        }

        /////////Registraatioonn /////////////
        [HttpGet]
        public ActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Role = 0;
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("LoggedIn");

            }
            else
            {
                ModelState.AddModelError("", "some error occured!");
            }
            return View(staff);
        }

        /////////////////ListCustomers////////////////
        public ActionResult ListCustomers() 
        {
            return View(db.Customer.ToList());
        }

        ////////////////ADD CUSTOMER////////////
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("ListCustomers");
            }
            else
            {
                ModelState.AddModelError("", "some error occured!");
            }
            return View();
        }
        //---------------------ADD EMPLOYEE--------------------------------------------

        public ActionResult AddEmployee ()
        {
            Staff staff = new Staff();

            return View(staff);
        }
        [HttpPost]
        public ActionResult AddEmployee (Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("ListEmployees");
            }

            return View(staff);
        }
        //----------------------UPDATE EMPLOYEE--------------------------------------------------------------

        public ActionResult UpdateEmployeeProfile(int? id)
        {
             if (id == null)
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             Staff staff = db.Staff.Find(id);
             if (staff == null)
                 return HttpNotFound();
             return View(staff);
        }

        [HttpPost]
        public ActionResult UpdateEmployeeProfile(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListEmployees");
            }
            return View(staff);
        }

        //------------------------DELETE EMPLOYEE-------------------------------------------------------

        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Staff staff = db.Staff.Find(id);
            if (staff == null)
                return HttpNotFound();
            return View(staff);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            Staff staff = db.Staff.Find(id);
            db.Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("ListEmployees");
           
        }


    }
}