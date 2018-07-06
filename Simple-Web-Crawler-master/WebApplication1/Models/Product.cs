using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    /// <summary>
    /// 产品返现信息
    /// </summary>
    public class ProductFinance : CYQ.Data.Orm.OrmBase
    {
        public ProductFinance()
        {
            base.SetInit(this);
        }
        public string FinanceGuid { get; set; }
        public string InsuranceGuid { get; set; }
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
    public class Insurance : CYQ.Data.Orm.OrmBase
    {
        public Insurance()
        {
            base.SetInit(this);
        }
        public string InsuranceGuid { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }

    public class UrlObject
    {

        public string ObjectName { get; set; }

        public Uri Uri { get; set; }



    }
}
