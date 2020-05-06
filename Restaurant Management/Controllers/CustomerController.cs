using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant_Management.Models;
using Restaurant_Management.Context;

namespace Restaurant_Management.Controllers
{
    public class CustomerController : Controller
    {
        Resturant db = new Resturant();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult UpdateProfile(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Customer customer = db.Customer.Find(id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult UpdateProfile(Customer customer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Customer product = db.Customer.Find(id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    customer = db.Customer.Find(id);
                    if (customer == null)
                        return HttpNotFound();
                    db.Customer.Remove(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }
    }
}
