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
    public class MonedasController : Controller
    {
        private DB_A372E9_nopcurvasDesignEntities db = new DB_A372E9_nopcurvasDesignEntities();

        // GET: Moneda
        public ActionResult Index()
        {
            return View(db.Moneda.ToList());
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = db.Moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Valor,Eliminado,CreadoUTC,ModificadoUTC")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                db.Moneda.Add(moneda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moneda);
        }

        // GET: Moneda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = db.Moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        // POST: Moneda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMoneda,Nombre,Valor,Eliminado,CreadoUTC,ModificadoUTC")] Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moneda);
        }

        // GET: Moneda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moneda moneda = db.Moneda.Find(id);
            if (moneda == null)
            {
                return HttpNotFound();
            }
            return View(moneda);
        }

        // POST: Moneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moneda moneda = db.Moneda.Find(id);
            db.Moneda.Remove(moneda);
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
