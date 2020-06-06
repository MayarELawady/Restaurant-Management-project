using Restaurant_Management.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Management.Models;
using Restaurant_Management.ViewModel;
using System.Data.Entity;
using System.Net;

namespace Restaurant_Management.Controllers
{
    public class orderController : Controller
    {
        Resturant db = new Resturant();
        // GET: order
        public ActionResult ListOrders()
        {
            return View(db.Order.ToList());
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            var dbValues = db.Staff.ToList();

            ViewBag.staffDropdownList = new SelectList(dbValues.Select(item => new SelectListItem
            {

                Text = item.UserName, //l textt l 3ayzeenoo yzhaar x drop down list ll user//
                Value = item.StaffId.ToString() // l value l hatt-save x database l ana 3ayzaha m3aya//
            }).ToList(), "Value", "Text");


            var dbValues2 = db.Customer.ToList();
            ViewBag.CustomerDropdownList = new SelectList(dbValues2.Select(item => new SelectListItem
            {

                Text = item.Name, //l textt l 3ayzeenoo yzhaar x drop down list ll user//
                Value = item.CustomerId.ToString() // l value l hatt-save x database l ana 3ayzaha m3aya//
            }).ToList(), "Value", "Text");

            return View();
        }
        [HttpPost]
        public ActionResult MakeOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("ListOrders");
            }
            else
            {
                ModelState.AddModelError("", "some error occured!");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Order order = db.Order.Find(id);
            if (order == null)
                return HttpNotFound();
            return View(order);
        }

        
        [HttpPost]
        public ActionResult Delete(int? id, Order order)
        {
            try
            {
                // TODO: Add delete logic here

                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    order = db.Order.Find(id);
                    if (order == null)
                        return HttpNotFound();
                    db.Order.Remove(order);
                    db.SaveChanges();
                    return RedirectToAction("ListOrders");
                }
                return View(order);
            }
            catch
            {
                return View();
            }
        }
    }
}
