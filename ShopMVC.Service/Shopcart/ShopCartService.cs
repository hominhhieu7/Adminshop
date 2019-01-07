using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data;
using ShopMVC.Data.Entity;
namespace ShopMVC.Service.Shopcart
{
    public interface IShopCartService
    {
        tbl_Product tbl_Product_Get(int id);
        string Order(string Orderxml);
    }
    public class ShopCartService: IShopCartService
    {
        UnitOfWork _unitOfWork = new UnitOfWork();

        public tbl_Product tbl_Product_Get(int id)
        {
            return _unitOfWork.ProductRepository.GetById(id);
        }

        public string Order(string Orderxml)
        {
            var sqlquery = "exec sp_OrderOrderDetailCustomer_xml_Save N'" + Orderxml + "'";
            return _unitOfWork.Context.Database.SqlQuery<string>(sqlquery).FirstOrDefault();
        }

    }
}
