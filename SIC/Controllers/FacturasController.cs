using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Entidad;
using shanuMVCUserRoles.BussinesLogic;
using static shanuMVCUserRoles.Entidad.Factura;

namespace shanuMVCUserRoles.Controllers
{
    public class FacturasController : Controller
    {
        
        private DB_A372E9_nopcurvasDesignEntities db = new DB_A372E9_nopcurvasDesignEntities();

        private FacturaLogic fl = new FacturaLogic();
        private InventarioLogic il = new InventarioLogic();

        // GET: Facturas
        public ActionResult Index()
        {
            var factura = db.Factura.Include(f => f.Cliente).Include(f => f.Sucursal).Include(f => f.Vendedor);
            return View(factura.ToList());
        }

        public JsonResult BuscarProducto (string Sku)
        {
            return Json(il.Buscar(Sku));
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        public ActionResult Registrar()
        {
            return View(new FacturaViewModel());
        }

        [HttpPost]
        public ActionResult Registrar(FacturaViewModel model, string action)
        {
            if (action == "generar")
            {
                if (!string.IsNullOrEmpty(model.Cliente))
                {
                    if (fl.Registrar(model.ToModel()))
                    {
                        return Redirect("~/");
                    }
                }
                else
                {
                    ModelState.AddModelError("cliente", "Debe agregar un cliente para el comprobante");
                }
            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (!model.SeAgregoUnProductoValido())
                {
                    ModelState.AddModelError("producto_agregar", "Solo puede agregar un producto válido al detalle");
                }
                else if (model.ExisteEnDetalle(model.CabeceraProductoSku))
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    model.AgregarItemADetalle();
                }
            }
            else if (action == "retirar_producto")
            {
                model.RetirarItemDeDetalle();
            }
            else
            {
                throw new Exception("Acción no definida ..");
            }

            return View(model);
        }

        public ActionResult Detalle(int id)
        {
            return View(fl.Obtener(id));
        }

        

        //// GET: Facturas/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre");
        //    ViewBag.IdVendedor = new SelectList(db.Sucursal, "IdSucursal", "NombreSucursal");
        //    ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "NombreVendedor");
        //    return View();
        //}

        //// POST: Facturas/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdFactura,IdCliente,SubTotal,GranTotal,Fecha,Descuento,IdVendedor,NumFactura,TasaCambio,Anulado,IVA,IdSacursal,Moneda")] Factura factura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Factura.Add(factura);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", factura.IdCliente);
        //    ViewBag.IdVendedor = new SelectList(db.Sucursal, "IdSucursal", "NombreSucursal", factura.IdVendedor);
        //    ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "NombreVendedor", factura.IdVendedor);
        //    return View(factura);
        //}

        //// GET: Facturas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Factura factura = db.Factura.Find(id);
        //    if (factura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", factura.IdCliente);
        //    ViewBag.IdVendedor = new SelectList(db.Sucursal, "IdSucursal", "NombreSucursal", factura.IdVendedor);
        //    ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "NombreVendedor", factura.IdVendedor);
        //    return View(factura);
        //}

        //// POST: Facturas/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdFactura,IdCliente,SubTotal,GranTotal,Fecha,Descuento,IdVendedor,NumFactura,TasaCambio,Anulado,IVA,IdSacursal,Moneda")] Factura factura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(factura).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdCliente = new SelectList(db.Cliente, "IdCliente", "Nombre", factura.IdCliente);
        //    ViewBag.IdVendedor = new SelectList(db.Sucursal, "IdSucursal", "NombreSucursal", factura.IdVendedor);
        //    ViewBag.IdVendedor = new SelectList(db.Vendedor, "IdVendedor", "NombreVendedor", factura.IdVendedor);
        //    return View(factura);
        //}

        //// GET: Facturas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Factura factura = db.Factura.Find(id);
        //    if (factura == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(factura);
        //}

        //// POST: Facturas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Factura factura = db.Factura.Find(id);
        //    db.Factura.Remove(factura);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
