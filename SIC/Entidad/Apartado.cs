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
    
    public partial class Apartado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartado()
        {
            this.DetalleApartado = new HashSet<DetalleApartado>();
            this.Recibo = new HashSet<Recibo>();
        }
    
        public int IdApartado { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdSucursal { get; set; }
        public int IdVendedor { get; set; }
        public double TotalProducto { get; set; }
        public double Cuota { get; set; }
        public System.DateTime FechaCuotaUno { get; set; }
        public System.DateTime FechaCuotaDos { get; set; }
        public int IdCliente { get; set; }
        public double IVA { get; set; }
        public bool Anulado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleApartado> DetalleApartado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recibo> Recibo { get; set; }
    }
}
