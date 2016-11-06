using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class DetailOrder
    {

        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int count { get; set; }
        public long price { get; set; }

        [ForeignKey("Order_Id")]
        public virtual Order Order { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }
    }
}