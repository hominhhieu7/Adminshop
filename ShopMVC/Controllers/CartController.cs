using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Data;
using ShopMVC.Service.Product;
using ShopMVC.Service.Shopcart;

namespace ShopMVC.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly Itbl_ProductService _tblProductService = new tbl_ProductService();
        private readonly IShopCartService _shopCartService = new ShopCartService();
        private Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null) //Người dùng đầu tiên nhấn nút chọn mua
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult CartPartial()
        {
            if (GetCart().TotalProduct() == 0)
            {
                ViewBag.TotalProduct = 0;
                ViewBag.TotalMoney = 0;
                return PartialView();
            }
            ViewBag.TotalProduct = GetCart().TotalProduct();
            ViewBag.TotalMoney = GetCart().Totalmoney();
            return PartialView();
        }
        public ActionResult AddToCart(int id, int Quanlity = 1)
        {
            var product = _tblProductService.tbl_Product_Get(id); //Get id product
            if (product != null)
                GetCart().Add(product, Quanlity);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateToCart(int id, int quanlity = 0)
        {
            GetCart().Update(id, quanlity); //Phương thức xây dựng trong model
            return Json("",JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveFromCart(int id)
        {
            Cart cart = GetCart();
            cart.Remove(id);
            if (cart.Items.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }

        public ActionResult Addcart()
        {
            Cart cart = GetCart();
            if (cart == null)
            {
                return View("ThongBao");
            }
                ViewBag.List = cart.Items;
                ViewBag.Totalmoney = GetCart().Totalmoney();
            return View();
        }

        public ActionResult Order(string Order)
        {
           var data = _shopCartService.Order(Order);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}