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
    
    public partial class tbl_DiscountCompaign
    {
        public int DiscountCompaignId { get; set; }
        public string CompaignName { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public Nullable<double> DiscountMoney { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
