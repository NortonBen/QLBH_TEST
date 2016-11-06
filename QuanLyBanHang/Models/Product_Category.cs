using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class Product_Category
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }
    }
}