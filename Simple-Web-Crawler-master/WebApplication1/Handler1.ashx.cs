using ClassLibrary1.Models;
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
            string page = context.Request["page"];
            string limit = context.Request["limit"];
            string key = context.Request["key"];

            var result = ProductService.GetAllProduct(Convert.ToInt32(page), Convert.ToInt32(limit),key);
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