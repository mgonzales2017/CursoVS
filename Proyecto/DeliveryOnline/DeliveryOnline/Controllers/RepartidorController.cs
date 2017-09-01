using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryOnline.Models;

namespace DeliveryOnline.Controllers
{
    public class RepartidorController : Controller
    {
        private DeliveryContext db = new DeliveryContext();

        // GET: Repartidor
        public ActionResult Index()
        {
            var repartidor = db.Repartidor.Include(r => r.Tienda);
            return View(repartidor.ToList());
        }

        // GET: Repartidor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repartidor repartidor = db.Repartidor.Find(id);
            if (repartidor == null)
            {
                return HttpNotFound();
            }
            return View(repartidor);
        }

        // GET: Repartidor/Create
        public ActionResult Create()
        {
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion");
            return View();
        }

        // POST: Repartidor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoId,TiendaId,Estado,Nombre")] Repartidor repartidor)
        {
            if (ModelState.IsValid)
            {
                db.Repartidor.Add(repartidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", repartidor.TiendaId);
            return View(repartidor);
        }

        // GET: Repartidor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repartidor repartidor = db.Repartidor.Find(id);
            if (repartidor == null)
            {
                return HttpNotFound();
            }
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", repartidor.TiendaId);
            return View(repartidor);
        }

        // POST: Repartidor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoId,TiendaId,Estado,Nombre")] Repartidor repartidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repartidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiendaId = new SelectList(db.Tiendas, "CodigoId", "Direccion", repartidor.TiendaId);
            return View(repartidor);
        }

        // GET: Repartidor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repartidor repartidor = db.Repartidor.Find(id);
            if (repartidor == null)
            {
                return HttpNotFound();
            }
            return View(repartidor);
        }

        // POST: Repartidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repartidor repartidor = db.Repartidor.Find(id);
            db.Repartidor.Remove(repartidor);
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
