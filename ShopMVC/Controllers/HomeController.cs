using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Service.Product;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly Itbl_ProductService _productService = new tbl_ProductService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index_Loadproduct()
        {
            var data = _productService.tbl_Product_GetAl().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index_Loadproduct2()
        {
            var data = _productService.tbl_Product_GetMany().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}