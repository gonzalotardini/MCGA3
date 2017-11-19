//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASF.Data.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.CartItem = new HashSet<CartItem>();
            this.OrderDetail = new HashSet<OrderDetail>();
            this.Rating = new HashSet<Rating>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DealerId { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public int QuantitySold { get; set; }
        public double AvgStars { get; set; }
        public Nullable<System.Guid> Rowid { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual Dealer Dealer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
