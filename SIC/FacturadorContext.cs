using shanuMVCUserRoles.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace shanuMVCUserRoles
{
    public class FacturadorContext : DbContext
    {
        public FacturadorContext()
            : base("name=FacturadorContext")
        {
        }

        public virtual DbSet<Factura> Comprobante { get; set; }
        public virtual DbSet<DetalleFactura> ComprobanteDetalle { get; set; }
        public virtual DbSet<vInventario> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .Property(e => e.Cliente);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.DetalleFactura)
                .WithRequired(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vInventario>()
                .Property(e => e.Sku)
                .IsUnicode(false);

            modelBuilder.Entity<vInventario>()
                .HasMany(e => e.DetalleFactura)
                .WithRequired(e => e.vInventario)
                .WillCascadeOnDelete(false);
        }
    }
}