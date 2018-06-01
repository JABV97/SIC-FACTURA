using shanuMVCUserRoles.Entidad;
using System.Collections.Generic;
using System.Linq;

namespace shanuMVCUserRoles.BussinesLogic
{
    public class InventarioLogic
    {
        public List<vInventario> Buscar(string Sku)
        {
            using (var context = new FacturadorContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var productos = context.Producto.OrderBy(x => x.Sku)
                                        .Where(x => x.Sku.Contains(Sku))
                                        .Take(10)
                                        .ToList();

                return productos;
            }
        }
    }
}