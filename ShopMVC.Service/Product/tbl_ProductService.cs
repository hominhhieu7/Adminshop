using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data.Entity;

namespace ShopMVC.Service.Product
{
    public interface Itbl_ProductService
    {
        IEnumerable<tbl_Product> tbl_Product_GetAl();
        IEnumerable<tbl_Product> tbl_Product_GetAlladmin();
        tbl_Product tbl_Product_Get(int ProductID);
        bool Add(tbl_Product model);
        int AddorEditStore(string xml);
        IEnumerable<tbl_Product> tbl_Product_GetMany();
        IEnumerable<tbl_Product> tbl_Product_GetGroupProdct(tbl_Product model);
    }
    public class tbl_ProductService: Itbl_ProductService
    {
        UnitOfWork _unitOfWork = new UnitOfWork();
        public IEnumerable<tbl_Product> tbl_Product_GetAl()
        {
            return _unitOfWork.ProductRepository.GetAll().OrderByDescending(p => p.ProductID).Take(4);
        }
        public IEnumerable<tbl_Product> tbl_Product_GetAlladmin()
        {
            return _unitOfWork.ProductRepository.GetAll().OrderByDescending(p => p.ProductID);
        }
        public IEnumerable<tbl_Product> tbl_Product_GetGroupProdct(tbl_Product model)
        {
            return _unitOfWork.ProductRepository.GetMany(p => p.GroupProductID == model.GroupProductID);
        }
        public IEnumerable<tbl_Product> tbl_Product_GetMany()
        {
            return _unitOfWork.ProductRepository.GetMany(p => p.GroupProductID == 2).OrderByDescending(p => p.ProductID).Take(4);
        }
        public tbl_Product tbl_Product_Get(int ProductID)
        {
            return _unitOfWork.ProductRepository.Get(p => p.ProductID == ProductID);
        }
        public bool Add(tbl_Product model)
        {
            return _unitOfWork.ProductRepository.Insert(model);
        }

        public int AddorEditStore(string xml)
        {
           return  _unitOfWork.Context.Database.SqlQuery<int>("").FirstOrDefault();
        }
    }
}
