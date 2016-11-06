using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{

    public class DataContext : DbContext
    {
        public DataContext() : base("name=Database")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User_Role> User_Role { get; set; }
        public virtual DbSet<Permission_Role> Permission_Role { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product_Category> Product_Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<DetailOrder> DetailOrder { get; set; }

    }
}