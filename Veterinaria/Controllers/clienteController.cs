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
    public class clienteController : Controller
    {
        private veterinariaEntities1 db = new veterinariaEntities1();

        // GET: cliente
        public ActionResult Index()
        {
            return View(db.tbl_cliente.ToList());
        }

        // GET: cliente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cliente);
        }

        // GET: cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_c,nombre_c,apellido_c,fechaNacimiento_c,edad_c")] tbl_cliente tbl_cliente)
        {
            if (ModelState.IsValid)
            {
                db.tbl_cliente.Add(tbl_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_cliente);
        }

        // GET: cliente/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cliente);
        }

        // POST: cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_c,nombre_c,apellido_c,fechaNacimiento_c,edad_c")] tbl_cliente tbl_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_cliente);
        }

        // GET: cliente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            if (tbl_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tbl_cliente);
        }

        // POST: cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_cliente tbl_cliente = db.tbl_cliente.Find(id);
            db.tbl_cliente.Remove(tbl_cliente);
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
