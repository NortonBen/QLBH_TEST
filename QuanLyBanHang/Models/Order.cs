using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class Order
    {
        public Order()
        {
            this.DetailOrder = new HashSet<DetailOrder>();
        }
        public int Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Created { get; set; }
        public long price { get; set; }
        public byte status { get; set; }
        public virtual ICollection<DetailOrder> DetailOrder { get; set; }
    }
}