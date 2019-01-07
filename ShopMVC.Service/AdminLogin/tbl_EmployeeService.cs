using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data.Entity;

namespace ShopMVC.Service.AdminLogin
{
    public interface Itbl_EmployeeeService
    {
        tbl_Employee tbl_Employee_Get(tbl_Employee objEmployee);
    }

    public class tbl_EmployeeeService : Itbl_EmployeeeService
    {
        UnitOfWork _unitOfWork = new UnitOfWork();
        public tbl_Employee tbl_Employee_Get(tbl_Employee obj)
        {
            var data =
                _unitOfWork.EmployeeRepository.Get(
                    p => p.AccountEmployee == obj.AccountEmployee && p.C_Password == obj.C_Password);
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}
