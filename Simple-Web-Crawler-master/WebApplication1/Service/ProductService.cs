using ClassLibrary1.Models;
using CYQ.Data;
using CYQ.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Service
{
    public class ProductService
    {

        public static string GetAllProduct(int page, int limit, string key)
        {
            //ProductFinance p = new ProductFinance();
            //MDataTable mt = p.Select();
            MAction action = new MAction("ProductFinance");
            MDataTable mt = action.Select(page, limit, " Name like '%" + key + "%'");
            return mt.ToJson();
        }
    }
}
