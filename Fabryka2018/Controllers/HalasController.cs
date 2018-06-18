using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fabryka2018;

namespace Fabryka2018.Controllers
{
    public class HalasController : Controller
    {
        private ModelDataContainer db = new ModelDataContainer();

        // GET: Halas
        public ActionResult Index()
        {
            return View(db.Halas.ToList());
        }

        // GET: Halas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // GET: Halas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Halas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Adres")] Hala hala)
        {
            if (ModelState.IsValid)
            {
                db.Halas.Add(hala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hala);
        }

        // GET: Halas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // POST: Halas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Adres")] Hala hala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hala);
        }

        // GET: Halas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // POST: Halas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hala hala = db.Halas.Find(id);
            db.Halas.Remove(hala);
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
