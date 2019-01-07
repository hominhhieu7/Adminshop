using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Data.Entity;
using ShopMVC.Service.Product;
namespace ShopMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly Itbl_ProductService _productService = new tbl_ProductService();
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Detail_Product(int id)
        {
            return View(_productService.tbl_Product_Get(id));
        }
    }
}