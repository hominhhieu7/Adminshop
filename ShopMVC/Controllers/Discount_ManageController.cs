using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Data.Entity;
using ShopMVC.Service.Discount_Manage;
using ShopMVC.Service.Product;
using ShopMVC.Service.QuanlyPd;

namespace ShopMVC.Controllers
{
    public class Discount_ManageController : Controller
    {
        private readonly Itbl_DiscountCompaignService _discountCompaign = new tbl_DiscountmanageService();
        private readonly Itbl_ProductService _tbl_Product = new tbl_ProductService();
        // GET: Discount
        public ActionResult Index_Discount()
        {
            var data = _discountCompaign.tbl_DiscountCompaign_GetAll().ToList().OrderByDescending(p => p.DiscountCompaignId);
            ViewBag.Listall = data;
            var dataproduct = _tbl_Product.tbl_Product_GetAlladmin().ToList();
            ViewBag.Listallproduct = dataproduct;
            return View(data);
        }
        public ActionResult Add(tbl_DiscountCompaign obj)
        {
            obj.CreateDate = DateTime.Now;
            var data = _discountCompaign.Addnew(obj);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
    }
}