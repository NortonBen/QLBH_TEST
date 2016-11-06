using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Models
{
    public class Product
    {
        public Product()
        {
            this.Product_Category = new HashSet<Product_Category>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string image { get; set; }
        public string describe { get; set; }
        [AllowHtml]
        public string detail { get; set; }
        public long price { get; set; }
        public byte status { get; set; }
        public string extension { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public virtual ICollection<Product_Category> Product_Category { get; set; }
        public virtual ICollection<DetailOrder> DetailOrder { get; set; }
    }
}