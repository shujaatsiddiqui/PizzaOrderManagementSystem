using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaOrderManagementSystem.Controllers
{
    public class PizzaManagmentController : Controller
    {
        // GET: PizzaManagment
        //public ActionResult Index()
        //{
        //    using (PizzaDbEntities en = new PizzaDbEntities())
        //    {
        //        return View(en.PizzaOrders_tb.ToList());
        //    }
        //}

        public ActionResult Index(string DeliveryStatus)
        {
            using (PizzaDbEntities en = new PizzaDbEntities())
            {
                if(string.IsNullOrEmpty(DeliveryStatus))
                    return View(en.PizzaOrders_tb.ToList());
                else
                    return View(en.PizzaOrders_tb.Where(r=>r.DeliveryStatus 
                                                         == DeliveryStatus).ToList());
            }
        }

        // GET: PizzaManagment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PizzaManagment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaManagment/Create
        [HttpPost]
        public ActionResult Create(PizzaOrders_tb pizzaOrdermodelObj)
        {
            try
            {
                using (PizzaDbEntities en = new PizzaDbEntities())
                {
                    en.PizzaOrders_tb.Add(pizzaOrdermodelObj);
                    en.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: PizzaManagment/Edit/5
        public ActionResult Edit(int id)
        {
            using (PizzaDbEntities en = new PizzaDbEntities())
            {
                return View(en.PizzaOrders_tb.Where(r=>r.OrderId == id).FirstOrDefault());
            }
        }

        // POST: PizzaManagment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PizzaOrders_tb orderObj)
        {
            try
            {
                using (PizzaDbEntities en = new PizzaDbEntities())
                {
                    en.Entry(orderObj).State = System.Data.Entity.EntityState.Modified;
                    en.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaManagment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaManagment/Delete/5
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
