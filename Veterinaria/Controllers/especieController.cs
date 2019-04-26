using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class especieController : Controller
    {
        private veterinariaEntities db = new veterinariaEntities();

        // GET: especie
        public ActionResult Index()
        {
            return View(db.tbl_especie.ToList());
        }

        // GET: especie/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especie tbl_especie = db.tbl_especie.Find(id);
            if (tbl_especie == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especie);
        }

        // GET: especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: especie/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_e,nombre_e")] tbl_especie tbl_especie)
        {
            if (ModelState.IsValid)
            {
                db.tbl_especie.Add(tbl_especie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_especie);
        }

        // GET: especie/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especie tbl_especie = db.tbl_especie.Find(id);
            if (tbl_especie == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especie);
        }

        // POST: especie/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_e,nombre_e")] tbl_especie tbl_especie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_especie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_especie);
        }

        // GET: especie/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_especie tbl_especie = db.tbl_especie.Find(id);
            if (tbl_especie == null)
            {
                return HttpNotFound();
            }
            return View(tbl_especie);
        }

        // POST: especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_especie tbl_especie = db.tbl_especie.Find(id);
            db.tbl_especie.Remove(tbl_especie);
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
