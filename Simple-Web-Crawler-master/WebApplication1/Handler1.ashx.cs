﻿using ClassLibrary1.Models;
using ClassLibrary1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var result = ProductService.GetAllProduct();
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}