using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Entidad;

namespace shanuMVCUserRoles.Controllers
{
    [Authorize]
    public class DescuentosController : Controller
    {
        private DB_A372E9_nopcurvasDesignEntities db = new DB_A372E9_nopcurvasDesignEntities();

        // GET: Descuentos
        public ActionResult Index()
        {
            return View(db.Descuento.ToList());
        }

        // GET: Descuentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // GET: Descuentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descuentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,deduccion,Eliminado,CreadoUTC,ModificadoUTC,activo")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Descuento.Add(descuento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descuento);
        }

        // GET: Descuentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: Descuentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDescuento,nombre, deduccion, Eliminado, CreadoUTC, ModificadoUTC, activo")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descuento);
        }

        // GET: Descuentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "IdDescuento,nombre, deduccion, Eliminado, CreadoUTC, ModificadoUTC, activo")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descuento);
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
