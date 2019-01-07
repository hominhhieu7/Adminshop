using System;
using ShopMVC.Data.Entity;
using ShopMVC.Service;

//using NetCoSoft.Service.MobileService;
//using NetCoSoft.Service.Models.LogisticsModel.QldmsModel;
//using NetCoSoft.Service.CrmService;

namespace ShopMVC.Service
{
    public class UnitOfWork : IDisposable
    {
        #region Fields

        public readonly BANHANG_THUCTAPEntities Context = new BANHANG_THUCTAPEntities();
        private BaseRepository<tbl_Product> _productRepository;
        private BaseRepository<tbl_GroupProduct> _groupProductRepository;
        private BaseRepository<tbl_Employee> _employeeRepository;
        private BaseRepository<tbl_DiscountCompaign> _discountcompaignRepository;
        #endregion

        #region Constructors and Destructors

        public BaseRepository<tbl_Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                {
                    this._employeeRepository = new BaseRepository<tbl_Employee>(Context);
                }
                return _employeeRepository;
            }
        }
        public BaseRepository<tbl_DiscountCompaign> DiscountcompaignRepository
        {
            get
            {
                if (this._discountcompaignRepository == null)
                {
                    this._discountcompaignRepository = new BaseRepository<tbl_DiscountCompaign>(Context);
                }
                return _discountcompaignRepository;
            }
        }
        public BaseRepository<tbl_Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new BaseRepository<tbl_Product>(Context);
                return _productRepository;
            }
        }

        public BaseRepository<tbl_GroupProduct> GroupRepository
        {
            get
            {
                if (this._groupProductRepository == null)
                {
                    this._groupProductRepository = new BaseRepository<tbl_GroupProduct>(Context);
                }
                return _groupProductRepository;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Save()
        {
            Context.SaveChanges();
        }
        #endregion

        #region Disposed

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
