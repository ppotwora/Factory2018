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
    public class MaszynasController : Controller
    {
        private ModelDataContainer db = new ModelDataContainer();

        // GET: Maszynas
        public ActionResult Index(string szukanaMaszyna)
        {
            if (string.IsNullOrEmpty(szukanaMaszyna))
            {
                var maszynies = db.Maszynas.Include(m => m.Hala).OrderBy(m => m.Nazwa);
                return View(maszynies.ToList());
            }
            else
            {
                var maszynies = db.Maszynas.Include(m => m.Hala).Where(m => m.Nazwa.Contains(szukanaMaszyna)).OrderBy(m => m.Nazwa);
                return View(maszynies.ToList());
            }
        }

        // GET: Maszynas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            return View(maszyna);
        }

        // GET: Maszynas/Create
        public ActionResult Create()
        {
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa");
            return View();
        }

        // POST: Maszynas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Data_uruchomienia,HalaId")] Maszyna maszyna)
        {
            if (ModelState.IsValid)
            {
                db.Maszynas.Add(maszyna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // GET: Maszynas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // POST: Maszynas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Data_uruchomienia,HalaId")] Maszyna maszyna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maszyna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // GET: Maszynas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            return View(maszyna);
        }

        // POST: Maszynas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maszyna maszyna = db.Maszynas.Find(id);
            db.Maszynas.Remove(maszyna);
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
