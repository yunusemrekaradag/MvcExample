using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SaleController : Controller
    {
        //Global:
        EFDbSalesEntities _efSales = new EFDbSalesEntities();

        // GET: Sale
        public ActionResult Index()
        {
            List<Sales> dataSales = _efSales.Sales.ToList();

            return View(dataSales);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> dataCustomers = (from c in _efSales.Customers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Value = c.id.ToString(),
                                                      Text = c.ad
                                                  }
                                                 ).ToList();
            ViewBag.dataCustomers = dataCustomers;

            //List<Customers> dataCustomers = _efSales.Customers.ToList();
            //ViewBag.dataCustomers = dataCustomers;

            List<Products> dataProducts = _efSales.Products.ToList();
            ViewBag.dataProducts = dataProducts;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Sales _sales)
        {
            _sales.Customers = _efSales.Customers.Find(_sales.customer_id);
            _sales.Products = _efSales.Products.Find(_sales.product_id);

            _efSales.Sales.Add(_sales);
            _efSales.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }

        public ActionResult Delete(int id)
        {
            _efSales.Sales.Remove(_efSales.Sales.Find(id));
            _efSales.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Customers> dataCustomers = _efSales.Customers.ToList();
            ViewBag.dataCustomers = dataCustomers;

            List<Products> dataProducts = _efSales.Products.ToList();
            ViewBag.dataProducts = dataProducts;

            Sales _sale = _efSales.Sales.Find(id);
            ViewBag.sale = _sale;

            return View();
        }

            [HttpPost]
            public ActionResult Edit(Sales _sales)
            {

                Sales sale = _efSales.Sales.Find(_sales.id);
                sale.quantity = _sales.quantity;
                sale.unit = _sales.unit;
                sale.customer_id = _sales.customer_id;
                sale.product_id = _sales.product_id;
                _efSales.SaveChanges();

                return RedirectToAction("Index");

            }
        }
}