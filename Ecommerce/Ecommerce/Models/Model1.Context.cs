﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EcommerceECDBEntities2 : DbContext
    {
        public EcommerceECDBEntities2()
            : base("name=EcommerceECDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category_> Category_ { get; set; }
        public virtual DbSet<Customer_> Customer_ { get; set; }
        public virtual DbSet<Editorial_> Editorial_ { get; set; }
        public virtual DbSet<Order_> Order_ { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Order_preorder> Order_preorder { get; set; }
        public virtual DbSet<Product_> Product_ { get; set; }
        public virtual DbSet<Product_Category_Detail> Product_Category_Detail { get; set; }
        public virtual DbSet<User_> User_ { get; set; }
    }
}
