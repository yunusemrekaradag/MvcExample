using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        //Global:
        EFDbSalesEntities _efSales = new EFDbSalesEntities();

        // GET: Product
        public ActionResult Index()
        {
            List<Products> dataProducts = _efSales.Products.ToList();

            return View(dataProducts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Products _product)
        {
            _efSales.Products.Add(_product);
            _efSales.SaveChanges();

            return RedirectToAction("Index");
            //return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Products _product = _efSales.Products.Find(id);
            ViewBag.product = _product;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Products _products)
        {
            Products _efProduct = _efSales.Products.Find(_products.id);
            _efProduct.ad=_products.ad;
            _efSales.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _efSales.Products.Remove(_efSales.Products.Find(id));
            _efSales.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}