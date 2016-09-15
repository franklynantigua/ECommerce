﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Classes;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    [Authorize(Roles = "User")]
    public class ProductsController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        // GET: Products
        public ActionResult Index()
        {
            var user = db.Users
                .Where(u => u.UserName == User.Identity.Name)
                .FirstOrDefault();
            var products = db.Products
                .Include(p => p.Category)
                .Include(p => p.Tax).Where(p => p.CompanyId == user.CompanyId);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(user.CompanyId), "CategoryId", "Description");
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxxes(user.CompanyId), "TaxId", "Description");
            var product = new Product {CompanyId = user.CompanyId};
            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {

                db.Products.Add(product);
                db.SaveChanges();
                var folder = "~/Content/Products";
                var file = string.Format("{0}.jpg", product.ProductId);
                var response = FilesHelper.UploadPhoto(product.ImageFile, folder, file);
                if (response)
                {

                    var pic = string.Format("{0}/{1}", folder, file);
                    product.Image = pic;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(user.CompanyId), "CategoryId", "Description",
                product.CategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxxes(user.CompanyId), "TaxId", "Description", product.TaxId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(product.CompanyId), "CategoryId",
                "Description");
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxxes(product.CompanyId), "TaxId", "Description");
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                if (product.ImageFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Products";
                    var file = string.Format("{0}.jpg", product.ProductId);
                    var response = FilesHelper.UploadPhoto(product.ImageFile, folder, file);
                    if (response)
                    {

                        pic = string.Format("{0}/{1}", folder, file);
                        product.Image = pic;

                    }
                }

                db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(product.CompanyId), "CategoryId",
                    "Description");
                ViewBag.TaxId = new SelectList(CombosHelper.GetTaxxes(product.CompanyId), "TaxId", "Description");
                return View(product);
        }
    

    // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var  product = db.Products.Find(id);
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
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
