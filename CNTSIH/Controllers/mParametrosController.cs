﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNTSIH.Models;

namespace CNTSIH.Controllers
{
    public class mParametrosController : Controller
    {
        private CSIHEntities db = new CSIHEntities();

        // GET: mParametros
        public async Task<ActionResult> Index()
        {
            return View(await db.mParametros.ToListAsync());
        }

        // GET: mParametros/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = await db.mParametros.FindAsync(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
            //return View();
        }

        // GET: mParametros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mParametros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "parametro_id,smtpserver,smtppuerto,correo_sistema,clave_correo,estado")] mParametros mParametros)
        {
            if (ModelState.IsValid)
            {
                db.mParametros.Add(mParametros);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mParametros);
        }

        // GET: mParametros/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = await db.mParametros.FindAsync(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
        }

        // POST: mParametros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "parametro_id,smtpserver,smtppuerto,correo_sistema,clave_correo,estado")] mParametros mParametros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mParametros).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mParametros);
        }

        // GET: mParametros/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mParametros mParametros = await db.mParametros.FindAsync(id);
            if (mParametros == null)
            {
                return HttpNotFound();
            }
            return View(mParametros);
        }

        // POST: mParametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mParametros mParametros = await db.mParametros.FindAsync(id);
            db.mParametros.Remove(mParametros);
            await db.SaveChangesAsync();
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
