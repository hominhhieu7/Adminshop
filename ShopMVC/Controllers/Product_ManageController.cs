using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Service.Product;

namespace ShopMVC.Controllers
{
    public class Product_ManageController : Controller
    {
        // GET: Product_Manage
        
        private readonly Itbl_ProductService _productService = new tbl_ProductService();
        public ActionResult Index()
        {
            var data = _productService.tbl_Product_GetAlladmin().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}