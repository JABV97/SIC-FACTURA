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
    
    public partial class Vendedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendedor()
        {
            this.Apartado = new HashSet<Apartado>();
            this.Factura = new HashSet<Factura>();
        }
    
        public int IdVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public string ApellidoVendedor { get; set; }
        public string CodVendedor { get; set; }
        public bool Eliminado { get; set; }
        public System.DateTime CreadoUTC { get; set; }
        public System.DateTime ModificadoUTC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apartado> Apartado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
