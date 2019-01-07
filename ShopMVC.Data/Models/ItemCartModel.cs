using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMVC.Data.Entity;

namespace ShopMVC.Data
{
    public class CartItem
    {
        public tbl_Product Product { get; set; }
        public int? Quanlity { get; set; }
    }

    public class Cart
    {
        //Field items
        List<CartItem> items = new List<CartItem>(); //Mỗi khi khách hàng mua 1 sp thì sẽ add vào list này
        //Proerty Items
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        //Method
        public void Add(tbl_Product pr, int Quanlity = 1)
        {
            //Cách 1 var item = items.FirstOrDefault(p => p.Sach.SachID == sach.SachID); //sài trong nội bộ nên sài field
            var item = items.Find(p => p.Product.ProductID == pr.ProductID); //do k kết nối database nên sài find hiệu quả hơn
            if (item == null) //san pham chưa có trong danh sách mua
            {
                items.Add(new CartItem {Product = pr, Quanlity = Quanlity});
            }
            else //san pham da co trong danh sach mua
            {
                item.Quanlity += Quanlity;
            }
        }

        public void Update(int id, int Quanlity)
        {
            var item = items.Find(p => p.Product.ProductID == id);
            if (item != null)
                item.Quanlity = Quanlity;
        }

        public void Remove(int id)
        {
            items.RemoveAll(p => p.Product.ProductID == id);
        }

        public double Totalmoney()
        {
            double kq = 0;//Truong hop gio hang trong
            var t = items.Sum(p => p.Product.PriceProduct * p.Quanlity);
            if (t != null)
                kq = t ?? 0;
            return kq;
        }
        
        public int? TotalProduct()
        {
            int kq = 0; //Truong hop gio hang trong
            var t = items.Sum(p => p.Quanlity);
            if (t != null)
                kq = t ?? 0;
            return kq;
        }
        public void Clear()
        {
            items.Clear();
        }
    }
}
