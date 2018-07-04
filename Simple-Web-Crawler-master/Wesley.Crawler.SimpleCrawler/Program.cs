using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using Wesley.Crawler.SimpleCrawler.Models;
using CYQ.Data;

namespace Wesley.Crawler.SimpleCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试代理IP是否生效：http://1212.ip138.com/ic.asp

            //测试当前爬虫的User-Agent：http://www.whatismyuseragent.net

            //1.抓取城市
            //CityCrawler();

            //2.抓取酒店
            //HotelCrawler();

            //3.并发抓取示例
            //ConcurrentCrawler();

            //4.分析已经抓取的数据

            InsuranceYuanGongBao.ConcurrentCrawler();

            Console.ReadKey();
        }

    }
}
















