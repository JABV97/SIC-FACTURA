﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A372E9_nopcurvasDesignEntities : DbContext
    {
        public DB_A372E9_nopcurvasDesignEntities()
            : base("name=DB_A372E9_nopcurvasDesignEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartado> Apartado { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Descuento> Descuento { get; set; }
        public virtual DbSet<DetalleApartado> DetalleApartado { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Gasto> Gasto { get; set; }
        public virtual DbSet<GastosOrganizacion> GastosOrganizacion { get; set; }
        public virtual DbSet<IVA> IVA { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<PagoFactura> PagoFactura { get; set; }
        public virtual DbSet<PagoRecibo> PagoRecibo { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public virtual DbSet<Recibo> Recibo { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<vInventario> vInventario { get; set; }
        public virtual DbSet<vPicture_Product> vPicture_Product { get; set; }
    
        public virtual int spInsertProductsInventory(string name, string color, string shortDescription, string tela, Nullable<decimal> price, string productPublishedString, string slugProducto, string categoryPrincipal, string slugCategoryPrincipal, string categorySecondary, string slugCategorySecondary, string sucursal, string talla, Nullable<int> inventoryQuantity, string skuShort)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("Color", color) :
                new ObjectParameter("Color", typeof(string));
    
            var shortDescriptionParameter = shortDescription != null ?
                new ObjectParameter("ShortDescription", shortDescription) :
                new ObjectParameter("ShortDescription", typeof(string));
    
            var telaParameter = tela != null ?
                new ObjectParameter("Tela", tela) :
                new ObjectParameter("Tela", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var productPublishedStringParameter = productPublishedString != null ?
                new ObjectParameter("ProductPublishedString", productPublishedString) :
                new ObjectParameter("ProductPublishedString", typeof(string));
    
            var slugProductoParameter = slugProducto != null ?
                new ObjectParameter("SlugProducto", slugProducto) :
                new ObjectParameter("SlugProducto", typeof(string));
    
            var categoryPrincipalParameter = categoryPrincipal != null ?
                new ObjectParameter("CategoryPrincipal", categoryPrincipal) :
                new ObjectParameter("CategoryPrincipal", typeof(string));
    
            var slugCategoryPrincipalParameter = slugCategoryPrincipal != null ?
                new ObjectParameter("SlugCategoryPrincipal", slugCategoryPrincipal) :
                new ObjectParameter("SlugCategoryPrincipal", typeof(string));
    
            var categorySecondaryParameter = categorySecondary != null ?
                new ObjectParameter("CategorySecondary", categorySecondary) :
                new ObjectParameter("CategorySecondary", typeof(string));
    
            var slugCategorySecondaryParameter = slugCategorySecondary != null ?
                new ObjectParameter("SlugCategorySecondary", slugCategorySecondary) :
                new ObjectParameter("SlugCategorySecondary", typeof(string));
    
            var sucursalParameter = sucursal != null ?
                new ObjectParameter("Sucursal", sucursal) :
                new ObjectParameter("Sucursal", typeof(string));
    
            var tallaParameter = talla != null ?
                new ObjectParameter("Talla", talla) :
                new ObjectParameter("Talla", typeof(string));
    
            var inventoryQuantityParameter = inventoryQuantity.HasValue ?
                new ObjectParameter("InventoryQuantity", inventoryQuantity) :
                new ObjectParameter("InventoryQuantity", typeof(int));
    
            var skuShortParameter = skuShort != null ?
                new ObjectParameter("SkuShort", skuShort) :
                new ObjectParameter("SkuShort", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertProductsInventory", nameParameter, colorParameter, shortDescriptionParameter, telaParameter, priceParameter, productPublishedStringParameter, slugProductoParameter, categoryPrincipalParameter, slugCategoryPrincipalParameter, categorySecondaryParameter, slugCategorySecondaryParameter, sucursalParameter, tallaParameter, inventoryQuantityParameter, skuShortParameter);
        }
    }
}
