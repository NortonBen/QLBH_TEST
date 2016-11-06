using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class Category
    {
        public Category()
        {
            this.Product_Category = new HashSet<Product_Category>();
        }
        public int Id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Product_Category> Product_Category { get; set; }
    }
}