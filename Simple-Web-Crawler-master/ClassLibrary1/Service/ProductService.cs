using ClassLibrary1.Models;
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
        public static string GetAllProduct()
        {
            ProductFinance p = new ProductFinance();
            MDataTable mt = p.Select();
            return mt.ToJson();
        }
    }
}
