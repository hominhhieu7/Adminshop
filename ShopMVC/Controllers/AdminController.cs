using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.Data.Entity;
using ShopMVC.Service.AdminLogin;

namespace ShopMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly Itbl_EmployeeeService _employeeService = new tbl_EmployeeeService();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["ten"] != null)
                return View();
            return RedirectToAction("Index_login", "Admin");
        }

        public ActionResult Login(tbl_Employee obj)
        {
            var data =_employeeService.tbl_Employee_Get(obj);
            if (data != null)
            {
                Session["ten"] = data.EmployeeName;
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index_login()
        {
            return View();
        }
    }
}