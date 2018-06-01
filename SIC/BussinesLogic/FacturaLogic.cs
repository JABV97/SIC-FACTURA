using shanuMVCUserRoles.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles.BussinesLogic
{
    public class FacturaLogic
    {
        public bool Registrar(Factura factura)
        {
            try
            {
                using (var context = new FacturadorContext())
                {
                    context.Entry(factura).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Factura Obtener(int id)
        {
            using (var context = new FacturadorContext())
            {
                // Esta consulta incluye el detalle del comprobante, y el producto que tiene cada comprobante. Me refiero a sus relaciones
                return context.Comprobante.Include(x => x.DetalleFactura.Select(y => y.vInventario))
                                          .Where(x => x.IdFactura == id)
                                          .SingleOrDefault();
            }
        }

        public List<Factura> Listar()
        {
            using (var context = new FacturadorContext())
            {
                return context.Comprobante.OrderByDescending(x => x.Fecha)
                                          .ToList();
            }
        }
    }
}