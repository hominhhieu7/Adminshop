//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopMVC.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Discount
    {
        public int DiscountId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> DiscountCompaignId { get; set; }
        public Nullable<double> TotalmoneyDiscount { get; set; }
    }
}
