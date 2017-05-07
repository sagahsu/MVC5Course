﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Model.ViewModel;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        private FabricsEntities1 db = new FabricsEntities1();


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductListVM data)
        {
            if (ModelState.IsValid)
            {
                //TODO: 儲存資炓進資料庫
                return RedirectToAction("ListProducts");
            }
            return View();
        }

        public ActionResult ListProducts()
        {
            var data = db.Product.Where(p => p.Active.Value == true)//NULL值處理用.HasValue()
                .Select(p => new ProductListVM()
                {
                     ProductName = p.ProductName,
                     Price= p.Price
                }).Take(10);
            return View(data);
        }
        // GET: Products
        public ActionResult Index(bool Active = true)
        {
            //return View(db.Product.ToList());
            //return View(db.Product.Take(10));//只取十筆
            var data = db.Product.Where(p=>p.Active.HasValue && p.Active.Value == Active)//NULL值處理用.HasValue()
                .OrderByDescending(p => p.ProductId).Take(10);
            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Product.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
