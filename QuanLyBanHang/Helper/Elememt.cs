﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Helper
{
    public class Elememt
    {
        public static string Select_Check(int input, int val)
        {
            if(input == val)
            {
                return "selected";
            }
            return "";
        }

        public static string Select_Check(List<Permission_Role> datas,int id)
        {
            var data = datas.Where(t => t.Permission_Id == id);
            if(data == null)
            {
                return "";
            }
            if ( data.Count() != 0){
                return "selected";
            }
            return "";
        }

        public static string Select_Check(List<Product_Category> datas, int id)
        {
            var data = datas.Where(t => t.Category_Id == id);
            if (data == null)
            {
                return "";
            }
            if (data.Count() != 0)
            {
                return "selected";
            }
            return "";
        }

    }
}