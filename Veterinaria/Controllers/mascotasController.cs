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
    public class mascotasController : Controller
    {
        private veterinariaEntities1 db = new veterinariaEntities1();

        // GET: mascotas
        public ActionResult Index()
        {
            var tbl_mascotas = db.tbl_mascotas.Include(t => t.tbl_cliente).Include(t => t.tbl_especie).Include(t => t.tbl_raza);
            return View(tbl_mascotas.ToList());
        }

        // GET: mascotas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascotas tbl_mascotas = db.tbl_mascotas.Find(id);
            if (tbl_mascotas == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mascotas);
        }

        // GET: mascotas/Create
        public ActionResult Create()
        {
            ViewBag.id_c = new SelectList(db.tbl_cliente, "id_c", "nombre_c");
            ViewBag.id_e = new SelectList(db.tbl_especie, "id_e", "nombre_e");
            ViewBag.id_r = new SelectList(db.tbl_raza, "id_r", "nombre_r");
            return View();
        }

        // POST: mascotas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_m,id_e,id_r,nombre_m,edad_m,sexo_m,id_c,fechaNacimiento_m")] tbl_mascotas tbl_mascotas)
        {
            if (ModelState.IsValid)
            {
                db.tbl_mascotas.Add(tbl_mascotas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_c = new SelectList(db.tbl_cliente, "id_c", "nombre_c", tbl_mascotas.id_c);
            ViewBag.id_e = new SelectList(db.tbl_especie, "id_e", "nombre_e", tbl_mascotas.id_e);
            ViewBag.id_r = new SelectList(db.tbl_raza, "id_r", "nombre_r", tbl_mascotas.id_r);
            return View(tbl_mascotas);
        }

        // GET: mascotas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascotas tbl_mascotas = db.tbl_mascotas.Find(id);
            if (tbl_mascotas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_c = new SelectList(db.tbl_cliente, "id_c", "nombre_c", tbl_mascotas.id_c);
            ViewBag.id_e = new SelectList(db.tbl_especie, "id_e", "nombre_e", tbl_mascotas.id_e);
            ViewBag.id_r = new SelectList(db.tbl_raza, "id_r", "nombre_r", tbl_mascotas.id_r);
            return View(tbl_mascotas);
        }

        // POST: mascotas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_m,id_e,id_r,nombre_m,edad_m,sexo_m,id_c,fechaNacimiento_m")] tbl_mascotas tbl_mascotas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_mascotas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_c = new SelectList(db.tbl_cliente, "id_c", "nombre_c", tbl_mascotas.id_c);
            ViewBag.id_e = new SelectList(db.tbl_especie, "id_e", "nombre_e", tbl_mascotas.id_e);
            ViewBag.id_r = new SelectList(db.tbl_raza, "id_r", "nombre_r", tbl_mascotas.id_r);
            return View(tbl_mascotas);
        }

        // GET: mascotas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_mascotas tbl_mascotas = db.tbl_mascotas.Find(id);
            if (tbl_mascotas == null)
            {
                return HttpNotFound();
            }
            return View(tbl_mascotas);
        }

        // POST: mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_mascotas tbl_mascotas = db.tbl_mascotas.Find(id);
            db.tbl_mascotas.Remove(tbl_mascotas);
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
