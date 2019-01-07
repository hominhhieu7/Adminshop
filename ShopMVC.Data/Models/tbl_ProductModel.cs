using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.Data.Models
{
    class tbl_ProductModel
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public double? PriceProduct { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public int? GroupProductID { get; set; }
        public string ProductCode { get; set; }
        public int? Quanlity { get; set; }
        public string images { get; set; }
        public string Decriptsion { get; set; }
    }
}
