using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        //private FabricsEntities1 db = new FabricsEntities1();
        ProductRepository productRespository = RepositoryHelper.GetProductRepository();
   
        // GET: EF
        public ActionResult Index()
        {
            //var all = productRespository.All();//db.Product.AsQueryable();//延遲載入
            //                                 //var all = db.Product.AsEnumerable();//立即載入
            //                                 //var data = all.Where(p => p.isDeleted ==false && p.Active == true && p.ProductName.Contains("Black"))
            //var data = all.Where(p => p.isDeleted!=true && p.Active == true && p.ProductName.Contains("Black"))
            //        .OrderByDescending(p=>p.ProductId);
            var data = productRespository.All(showAll:false);//具名參數
            return View(data);
        }

        // GET: EF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            //Product product = db.Database.SqlQuery<Product>("SELECT * FROM Product WHERE ProductId=@p0", id).FirstOrDefault();
            Product product = productRespository.findByProductId(id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: EF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EF/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Product.Add(product);
                //db.SaveChanges();
                productRespository.Create(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: EF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = productRespository.findByProductId(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: EF/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                productRespository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: EF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productRespository.findByProductId(id.Value);//db.Product.Find(id);

             if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: EF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = productRespository.findByProductId(id);//db.Product.Find(id);
            //foreach (var item in product.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            //db.OrderLine.RemoveRange(product.OrderLine);//一行抵上面四行

            //db.Product.Remove(product);
            productRespository.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;//關閉檢驗
            productRespository.Delete(product);
            productRespository.UnitOfWork.Commit();

            //db.SaveChanges();
            productRespository.Update(product);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
