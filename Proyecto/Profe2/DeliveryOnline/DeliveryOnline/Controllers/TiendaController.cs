﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeliveryOnline.Models;
using DeliveryOnline.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeliveryOnline.Controllers
{
    public class TiendaController : BaseController
    {        
        // GET: Tienda
        public ActionResult Index()
        {
            return View(DbContext.Tiendas.ToList());
        }

        public ActionResult UserIndex()
        {
            return View(DbContext.Tiendas.ToList());
        }

        // GET: Tienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tienda tienda = DbContext.Tiendas.Find(id);
            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // GET: Tienda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tienda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoId,Direccion,Estado,FechaRegsitro,NombreComercial,RazonSocial,Telefono")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                DbContext.Tiendas.Add(tienda);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tienda);
        }

        // GET: Tienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tienda tienda = DbContext.Tiendas.Find(id);
            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // POST: Tienda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoId,Direccion,Estado,FechaRegsitro,NombreComercial,RazonSocial,Telefono")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(tienda).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tienda);
        }

        // GET: Tienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tienda tienda = DbContext.Tiendas.Find(id);
            if (tienda == null)
            {
                return HttpNotFound();
            }
            return View(tienda);
        }

        // POST: Tienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tienda tienda = DbContext.Tiendas.Find(id);
            DbContext.Tiendas.Remove(tienda);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
