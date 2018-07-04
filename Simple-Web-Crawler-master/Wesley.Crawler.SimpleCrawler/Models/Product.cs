using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wesley.Crawler.SimpleCrawler.Models
{
    /// <summary>
    /// 产品返现信息
    /// </summary>
    public class ProductFinance
    {
        public string Name { get; set; }
        //缴费方式	保障期限	推广费率	特别奖励	邀请奖励
        public string JiaoFeiFangShi { get; set; }
        public string BaoZhangQiXian { get; set; }
        public string TuiGuangFeiLv { get; set; }
        public string TeBieJiangLi { get; set; }
        public string YaoQingJiangLi { get; set; }

        public override string ToString()
        {
            return string.Format("产品名：{0}--------{1}|{2}|{3}|{4}|{5}|", Name.Trim().PadLeft(10, ' '), JiaoFeiFangShi, BaoZhangQiXian, TuiGuangFeiLv, TeBieJiangLi, YaoQingJiangLi);
        }
    }
    /// <summary>
    /// 产品信息
    /// </summary>
    public class Insurance
    {
        public string Name { get; set; }

        public string Desc { get; set; }
    }

    public class UrlObject
    {

        public string ObjectName { get; set; }

        public Uri Uri { get; set; }



    }
}
