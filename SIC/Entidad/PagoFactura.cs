//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shanuMVCUserRoles.Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class PagoFactura
    {
        public int IdPagoFactura { get; set; }
        public int IdFactura { get; set; }
        public int IdMetodoPago { get; set; }
        public double Pagado { get; set; }
        public string Moneda { get; set; }
    
        public virtual Factura Factura { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
    }
}
