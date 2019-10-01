//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructionMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public Nullable<int> ReceiptID { get; set; }
        public Nullable<int> StaffID { get; set; }
        public Nullable<int> TotalOrder { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> GuestID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual Staff Staff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
