using System;
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
    public class mCatalogoController : Controller
    {
        private CSIHEntities db = new CSIHEntities();

        // GET: mCatalogo
        public async Task<ActionResult> Index()
        {
            return View(await db.mCatalogo.ToListAsync());
        }

        // GET: mCatalogo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // GET: mCatalogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mCatalogo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.mCatalogo.Add(mCatalogo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mCatalogo);
        }

        // GET: mCatalogo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // POST: mCatalogo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "mcatalogo_id,catalogo,estado")] mCatalogo mCatalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mCatalogo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mCatalogo);
        }

        // GET: mCatalogo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            return View(mCatalogo);
        }

        // POST: mCatalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            db.mCatalogo.Remove(mCatalogo);
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



        public async Task<ActionResult> CreateCatalogo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mCatalogo mCatalogo = await db.mCatalogo.FindAsync(id);
            if (mCatalogo == null)
            {
                return HttpNotFound();
            }
            var view = new Catalogo { mcatalogo_id = mCatalogo.mcatalogo_id, };
             return View(view);
        }

        // POST: Catalogo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCatalogo( Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Catalogo.Add(catalogo);
                await db.SaveChangesAsync();
                return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            }

            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        public async Task<ActionResult> EditCatalogo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = await db.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        // POST: Catalogo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCatalogo(Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            }
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            return View(catalogo);
        }

        public async Task<ActionResult> DeleteCatalogo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogo catalogo = await db.Catalogo.FindAsync(id);
            if (catalogo == null)
            {
                return HttpNotFound();
            }
            catalogo.estado = false;
            db.Entry(catalogo).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction(String.Format("Details/{0}", catalogo.mcatalogo_id));
            //ViewBag.mcatalogo_id = new SelectList(db.mCatalogo, "mcatalogo_id", "catalogo", catalogo.mcatalogo_id);
            //return View(catalogo);
        }
    }
}
