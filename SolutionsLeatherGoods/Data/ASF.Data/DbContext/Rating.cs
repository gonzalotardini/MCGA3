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
    
    public partial class Rating
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime ChangedOn { get; set; }
        public Nullable<int> ChangedBy { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}