using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data.Entity;

namespace ShopMVC.Service.QuanlyPd
{
    public interface Itbl_GroupProductService
    {
        IEnumerable<tbl_GroupProduct> tbl_GroupProduct_getall();
    }
    public class tbl_GroupProductService : Itbl_GroupProductService
    {
        UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<tbl_GroupProduct> tbl_GroupProduct_getall()
        {
            return _unitOfWork.GroupRepository.GetAll();
        }
    }
}
