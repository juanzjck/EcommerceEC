//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_preorder
    {
        public int idOrder_preorder { get; set; }
        public Nullable<int> idProduct { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> idCustomer { get; set; }
    
        public virtual Product_ Product_ { get; set; }
        public virtual Customer_ Customer_ { get; set; }
    }
}
