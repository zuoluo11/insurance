using CYQ.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wesley.Crawler.SimpleCrawler.Models;

namespace Wesley.Crawler.SimpleCrawler
{
    public class InsuranceYuanGongBao
    {

        /// <summary>
        /// 并发抓取示例
        /// </summary>
        public static void ConcurrentCrawler()
        {

            var objectListFinance = new List<UrlObject>() {
              
                new UrlObject { ObjectName="返现", Uri=new Uri("http://ygb.xiaoma66.cn/index.php/user/finance") },

               
            };
            var objectList = new List<UrlObject>() {

                      new UrlObject { ObjectName="首页", Uri=new Uri("http://ygb.xiaoma66.cn/prod/getInfoList/pt/0/sid/0/page/1") },
                        new UrlObject { ObjectName="重疾", Uri=new Uri("http://ygb.xiaoma66.cn/prod/getInfoList/pt/1/sid/0/page/1") },
                        new UrlObject { ObjectName="医疗", Uri=new Uri("http://ygb.xiaoma66.cn/prod/getInfoList/pt/6/sid/0/page/1") },
                        new UrlObject { ObjectName="意外", Uri=new Uri("http://ygb.xiaoma66.cn/prod/getInfoList/pt/2/sid/0/page/1") },
                        new UrlObject { ObjectName="寿险", Uri=new Uri("http://ygb.xiaoma66.cn/prod/getInfoList/pt/3/sid/0/page/1") },
               
            };

            var hotelCrawler = new SimpleCrawler();


            CookieContainer cc = new CookieContainer();

            cc.Add(new Cookie("PHPSESSID", "m9u38l2f8n0gt266ad268j96l7", "/", "ygb.xiaoma66.cn"));
            cc.Add(new Cookie("Hm_lvt_c2483700e96aa81244eca4879c40a6f7", "1530152446", "/", "ygb.xiaoma66.cn"));
            cc.Add(new Cookie("Hm_lpvt_c2483700e96aa81244eca4879c40a6f7", "1530166350", "/", "ygb.xiaoma66.cn"));

            hotelCrawler.CookiesContainer = cc;



            hotelCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine("爬虫开始抓取地址：" + e.Uri.ToString());
            };
            hotelCrawler.OnError += (s, e) =>
            {
                Console.WriteLine("爬虫抓取出现错误：" + e.Uri.ToString() + "，异常消息：" + e.Exception.Message);
            };
            hotelCrawler.OnCompleted += (s, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("===============================================");
                Console.Write(e.PageSource);
                Console.WriteLine();
                Console.WriteLine("爬虫抓取任务完成！");
                Console.WriteLine("耗时：" + e.Milliseconds + "毫秒");
                Console.WriteLine("线程：" + e.ThreadId);
                Console.WriteLine("地址：" + e.Uri.ToString());
                if (e.Uri.ToString().IndexOf("finance") > -1)
                {
                    AnaylizeFinanceData(e.PageSource);
                }
                else
                {
                    AnaylizeData(e.PageSource);
                }
                Log.WriteLogToTxt(e.PageSource);
            };
            //Parallel.For(0, objectList.Count, (i) =>
            //{
            //    var hotel = objectList[i];

            //    hotelCrawler.Start(hotel.Uri);
            //});
            Parallel.For(0, objectListFinance.Count, (i) =>
            {
                var hotel = objectListFinance[i];

                hotelCrawler.Start(hotel.Uri);
            });


        }


        /// <summary>
        /// 分析产品信息
        /// </summary>
        public static void AnaylizeData(string source)
        {
            //string source = File.ReadAllText(@"E:\project\study\Simple-Web-Crawler-master\Simple-Web-Crawler-master\Wesley.Crawler.SimpleCrawler\bin\Debug\Logs\20180625.txt", Encoding.Default);


            string tmpStr = string.Format(@"<h2>(?<name>.*)</h2>\s+<h3>(?<desc>.*)</h3>"); //获取

            var matchCollection = Regex.Matches(source, tmpStr, RegexOptions.IgnoreCase);

            var list = new List<Insurance>();
            foreach (Match match in matchCollection)
            {

                var name = match.Groups["name"].Value;
                var desc = match.Groups["desc"].Value.ToLower();
                Insurance insurance = new Insurance();

                insurance.Name = name;
                insurance.Desc = desc;

                list.Add(insurance);
                if (insurance.Exists(string.Format("name='{0}'", name)))
                {
                    Console.WriteLine("已存在" + name);
                    continue;
                }
                if (insurance.Insert(InsertOp.ID))
                {
                    Console.WriteLine("成功");
                }
                else
                {
                    Console.WriteLine("失败");
                }
                //Console.WriteLine(insurance.Name + "|" + insurance.Desc);

            }



        }


        /// <summary>
        /// 分析返利信息
        /// </summary>
        public static void AnaylizeFinanceData(string source)
        {
            var path = @"E:\project\github\insurance\Simple-Web-Crawler-master\Wesley.Crawler.SimpleCrawler\bin\Debug\Logs\finance.html";
            var doc = new HtmlDocument();
            doc.Load(path);

            //var doc = new HtmlDocument();
            //doc.LoadHtml(source);

            var nodes = doc.DocumentNode.SelectNodes("//body/section[1]/table/tr[@class='table-tr']");
            var productList = new List<ProductFinance>();
            foreach (var item in nodes)
            {
                //循环每一种产品

                //名称
                var nameNode = item.SelectSingleNode(".//td[@class='table-td' and @rows='3']");
                //Console.WriteLine(nameNode.InnerText);

                //内容
                var tableNodes = item.SelectNodes(".//table[@class='table1']/tr");
                foreach (var trNode in tableNodes)
                {
                    var tdNodes = trNode.SelectNodes(".//td");

                    var product = new ProductFinance
                    {
                        Name = nameNode.InnerText.Trim(),
                        JiaoFeiFangShi = tdNodes[0].InnerText.Trim(),
                        BaoZhangQiXian = tdNodes[1].InnerText.Trim(),
                        TuiGuangFeiLv = tdNodes[2].InnerText.Trim(),
                        TeBieJiangLi = tdNodes[3].InnerText.Trim(),
                        YaoQingJiangLi = tdNodes[4].InnerText.Trim()
                    };
                    Insurance insurance = new Insurance();
                    if (insurance.Fill(string.Format("name='{0}'", product.Name)))
                    {
                        product.InsuranceGuid = insurance.InsuranceGuid;
                    }
                    product.Insert();
                    productList.Add(product);



                }
            }

            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
