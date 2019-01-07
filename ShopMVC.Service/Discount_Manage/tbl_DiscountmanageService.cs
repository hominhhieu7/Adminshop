using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data.Entity;

namespace ShopMVC.Service.Discount_Manage
{
    public interface Itbl_DiscountCompaignService
    {
        IEnumerable<tbl_DiscountCompaign> tbl_DiscountCompaign_GetAll();
        bool Addnew(tbl_DiscountCompaign obj);
    }
    public class tbl_DiscountmanageService : Itbl_DiscountCompaignService
    {
        UnitOfWork _unitOfWork = new UnitOfWork();
        public bool Addnew(tbl_DiscountCompaign obj)
        {
            return _unitOfWork.DiscountcompaignRepository.Insert(obj);
        }

        public IEnumerable<tbl_DiscountCompaign> tbl_DiscountCompaign_GetAll()
        {
            return _unitOfWork.DiscountcompaignRepository.GetAll();
        }
    }
}
