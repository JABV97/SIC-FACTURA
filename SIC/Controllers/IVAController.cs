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
        public class IVAController : Controller
        {
            private DB_A372E9_nopcurvasDesignEntities db = new DB_A372E9_nopcurvasDesignEntities();

            // GET: IVAs
            public ActionResult Index()
            {
                return View(db.IVA.ToList());
            }

            // GET: IVAs/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IVA iVA = db.IVA.Find(id);
                if (iVA == null)
                {
                    return HttpNotFound();
                }
                return View(iVA);
            }

            // GET: IVAs/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: IVAs/Create
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "IVA1,Eliminado,CreadoUTC,ModificadoUTC")] IVA iVA)
            {
                if (ModelState.IsValid)
                {
                    db.IVA.Add(iVA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(iVA);
            }

            // GET: IVAs/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IVA iVA = db.IVA.Find(id);
                if (iVA == null)
                {
                    return HttpNotFound();
                }
                return View(iVA);
            }

            // POST: IVAs/Edit/5
            // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
            // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "IdIVA,IVA1,Eliminado,CreadoUTC,ModificadoUTC")] IVA iVA)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(iVA).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(iVA);
            }

            // GET: IVAs/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IVA iVA = db.IVA.Find(id);
                if (iVA == null)
                {
                    return HttpNotFound();
                }
                return View(iVA);
            }

            // POST: IVAs/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed([Bind(Include = "IdIVA,IVA1,Eliminado,CreadoUTC,ModificadoUTC")] IVA iVA)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(iVA).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(iVA);
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