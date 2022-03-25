using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        //Global:
        EFDbSalesEntities _efSales = new EFDbSalesEntities();

        // GET: Customer
        public ActionResult Index()
        {
            List<Customers> dataCustomers = _efSales.Customers.ToList();

            return View(dataCustomers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customers _customer)
        {
            _efSales.Customers.Add(_customer);
            _efSales.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }

        public ActionResult Delete(int id)
        {
            _efSales.Customers.Remove(_efSales.Customers.Find(id));
            _efSales.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customers _customer = _efSales.Customers.Find(id);
            ViewBag.customer = _customer;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Customers _customer)
        {
            Customers _efCustomer = _efSales.Customers.Find(_customer.id);
            _efCustomer.ad = _customer.ad;
            _efSales.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }
    }
}