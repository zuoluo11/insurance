using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OperateHTML
{
    class Program
    {
        static void Main(string[] args)
        {

            CookieContainer cc = new CookieContainer();
            string url_login = "https://m.jumi18.com/m/entrance/api-login";
            string postData_login = "mobile=15536642798&pass=15525432313&smscode=&type=1&openid=&imgcode=&appversion=5.2.0&idcode=128102920140760184743799232621869590523";
            string result_login = PostLogin(postData_login, url_login, ref cc);
            if (result_login.IndexOf("True") > -1)//1748表示登录成功
            {
                string url_getRyData = "https://api.jumi18.com/product/list";
                string postData_RyData = "appid=4&areaCode=140100&args=%7B%0A%20%20%22categoryId%22%20%3A%2055%2C%0A%20%20%22flashSearchType%22%20%3A%200%2C%0A%20%20%22tagId%22%20%3A%20%22%22%2C%0A%20%20%22searchType%22%20%3A%201%2C%0A%20%20%22rows%22%20%3A%2010%2C%0A%20%20%22IDCode%22%20%3A%20%22128102920140760184743799232621869590523%22%2C%0A%20%20%22tagName%22%20%3A%20%22%22%2C%0A%20%20%22page%22%20%3A%201%2C%0A%20%20%22VersionStr%22%20%3A%20%225.2.0%22%2C%0A%20%20%22keyWords%22%20%3A%20%22%22%2C%0A%20%20%22areaCode%22%20%3A%20%22140100%22%2C%0A%20%20%22companyId%22%20%3A%200%0A%7D&session=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP%2ABeWA2B2S%2ARPMVS5kFcFNBjzzdhSYbSWMemiWlC6ShgCupt1Q0TwIvA4w%21%21&sign=CF8AF452A1F802793E174FF9CA5EBDE2&timestamp=2018-07-04%2016%3A34%3A51&trace=12345";
                string result_RyData = PostRequest(postData_RyData, url_getRyData, cc);
                Console.WriteLine(result_RyData);
                if (result_RyData.Length == 0)
                {
                    //MessageBox.Show("对不起，没有查找到当前人信息。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            Console.Read();
        }




        /**
         * 
         * 
         * appid=4&areaCode=140100&args={
  "categoryId" : 55,
  "flashSearchType" : 0,
  "tagId" : "",
  "searchType" : 1,
  "rows" : 10,
  "IDCode" : "128102920140760184743799232621869590523",
  "tagName" : "",
  "page" : 1,
  "VersionStr" : "5.2.0",
  "keyWords" : "",
  "areaCode" : "140100",
  "companyId" : 0
}&session=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP*BeWA2B2S*RPMVS5kFcFNBjzzdhSYbSWMemiWlC6ShgCupt1Q0TwIvA4w!!&sign=CF8AF452A1F802793E174FF9CA5EBDE2&timestamp=2018-06-28 16:34:51&trace=12345
         * 
         * 
         * appid=4&areaCode=140100&args={
  "categoryId" : 54,
  "flashSearchType" : 0,
  "tagId" : "",
  "searchType" : 1,
  "rows" : 10,
  "IDCode" : "128102920140760184743799232621869590523",
  "tagName" : "",
  "page" : 1,
  "VersionStr" : "5.2.0",
  "keyWords" : "",
  "areaCode" : "140100",
  "companyId" : 0
}&session=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP*BeWA2B2S*RPMVS5kFcFNBjzzdhSYbSWMemiWlC6ShgCupt1Q0TwIvA4w!!&sign=15DE7406336788ADB79E256E3967858B&timestamp=2018-06-28 17:14:12&trace=12345
         * 
         * 
         * appid=4&areaCode=140100&args={
  "categoryId" : 54,
  "flashSearchType" : 0,
  "tagId" : "",
  "searchType" : 1,
  "rows" : 10,
  "IDCode" : "128102920140760184743799232621869590523",
  "tagName" : "",
  "page" : 1,
  "VersionStr" : "5.2.0",
  "keyWords" : "",
  "areaCode" : "140100",
  "companyId" : 0
}&session=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP*BeWA2B2S*RPMVS5kFcFNBjzzdhSYbSWMemiWlC6ShgCupt1Q0TwIvA4w!!&sign=E0801B51914CDCB99991A610B8106262&timestamp=2018-06-28 17:16:30&trace=12345
         */

        /**
         * 
         * 
         * {"ErrCode":0,"Data":{"rows":[{"recommended":false,"productId":1393,"productName":"慧择老年关爱(含重疾)","planId":1575,"planName":"计划一加强版","companyId":57,"companyName":"史带财险","companyShareUrl":"http://files.hzins.com/files/9/9f/9fa/9fa2/9fa29ed14da34f7fbf4c126defefd2da.png","sellCount":5717,"defaultPrice":179800,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"61-65周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"个人重大疾病保险\",\"value\":\"5万元\"},{\"item\":\"个人意外伤害保险\",\"value\":\"10万元\"},{\"item\":\"救护车服务津贴 \",\"value\":\"500元\"},{\"item\":\"意外医疗\",\"value\":\"2万元\"},{\"item\":\"意外每日住院津贴\",\"value\":\"100元/天\"}]","productFeatures":"[\"60岁以上可投保\",\"30种重疾保障全\",\"2万元意外医疗\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-1393-1575.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-1393-1575.html","vipProduct":false,"old":false},{"recommended":false,"productId":748,"productName":"慧择健康保障计划","planId":693,"planName":"","companyId":56,"companyName":"华泰财险","companyShareUrl":"http://files.hzins.com/files/b/b4/b43/b434/b434ab4c10a745a7872b8089aa62a4c4.png","sellCount":1367,"defaultPrice":48000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"18-45周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"重大疾病\",\"value\":\"10万元\"},{\"item\":\"住院津贴\",\"value\":\"100元∕天(免赔3天,单次事故最长90天,保险期间内累计最长180天)\"},{\"item\":\"重症监护津贴\",\"value\":\"200元∕天(单次事故最长30天,保险期间内累计最长60天)\"},{\"item\":\"意外身故、伤残\",\"value\":\"20万\"},{\"item\":\"意外医疗\",\"value\":\"1万(每次事故100元免赔,超出部分100%赔付)\"}]","productFeatures":"[\"众多白领人士选择\",\"含25种重疾保障\",\"住院含重症监护津贴\"]","buyQuota":"1","serviceFee":18,"serviceFeeDetail":"推广费18%","basicFeeRate":1800,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-748-693.html","addFeeRate":0,"renewalFeeRate":0,"productTag":"闪赔","productTagRGB":"4B73EB","productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-748-693.html","vipProduct":false,"old":false},{"recommended":false,"productId":1786,"productName":"女性特定疾病保险","planId":2140,"planName":"","companyId":1077,"companyName":"易安保险","companyShareUrl":"http://files.huizecdn.com/file1/M00/3B/2B/wKgls1seJ2WAXkwaAAAPJiaKUL8184.png","sellCount":12507,"defaultPrice":2000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"18-39周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"女性特定重大疾病保险金\",\"value\":\"10000\"},{\"item\":\"女性特定重大疾病保险金\",\"value\":\"已交保险费\"}]","productFeatures":"[\"涵盖女性高发重疾\",\"20万保障只需400元\",\"支持叮咚闪赔\"]","buyQuota":"20","serviceFee":15,"serviceFeeDetail":"推广费15%","basicFeeRate":1500,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-1786-2140.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-1786-2140.html","vipProduct":false,"old":false},{"recommended":false,"productId":1394,"productName":"慧择老年关爱(含重疾)","planId":1576,"planName":"计划二加强版","companyId":57,"companyName":"史带财险","companyShareUrl":"http://files.hzins.com/files/9/9f/9fa/9fa2/9fa29ed14da34f7fbf4c126defefd2da.png","sellCount":1132,"defaultPrice":199800,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"66-70周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"个人重大疾病保险\",\"value\":\"5万元\"},{\"item\":\"个人意外伤害保险\",\"value\":\"10万元\"},{\"item\":\"救护车服务津贴\",\"value\":\"500元\"},{\"item\":\"意外医疗\",\"value\":\"2万元\"},{\"item\":\"意外每日住院津贴\",\"value\":\"100元/天\"}]","productFeatures":"[\"60岁以上可投保\",\"30种重疾保障全\",\"2万元意外医疗\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-1394-1576.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-1394-1576.html","vipProduct":false,"old":false},{"recommended":false,"productId":857,"productName":"乐享人生-安联个人保障计划(幼儿版)","planId":829,"planName":"计划一","companyId":69,"companyName":"安联财险","companyShareUrl":"http://files.hzins.com/files/a/a2/a2f/a2fd/a2fd4f931a1a4653942d96639490999f.png","sellCount":685,"defaultPrice":38000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"出生满60日-6周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"意外身故/伤残\",\"value\":\"5万元\"},{\"item\":\"意外医疗\",\"value\":\"5000元\"},{\"item\":\"重大疾病保障\",\"value\":\"5万元\"},{\"item\":\"住院医疗\",\"value\":\"1万元\"},{\"item\":\"电话医生服务\",\"value\":\"包含\"}]","productFeatures":"[\"幼儿专属保障\",\"40种重疾保障\",\"意外/医疗全保障\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-857-829.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-857-829.html","vipProduct":false,"old":false},{"recommended":false,"productId":857,"productName":"乐享人生-安联个人保障计划(幼儿版)","planId":830,"planName":"计划二","companyId":69,"companyName":"安联财险","companyShareUrl":"http://files.hzins.com/files/a/a2/a2f/a2fd/a2fd4f931a1a4653942d96639490999f.png","sellCount":633,"defaultPrice":48000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"出生满60日-6周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"意外身故/伤残\",\"value\":\"10万元\"},{\"item\":\"意外医疗\",\"value\":\"1万元\"},{\"item\":\"重大疾病保障\",\"value\":\"10万元\"},{\"item\":\"住院医疗\",\"value\":\"1万元\"},{\"item\":\"电话医生服务\",\"value\":\"包含\"}]","productFeatures":"[\"幼儿专属保障\",\"40种重疾保障\",\"意外/医疗全保障\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-857-830.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-857-830.html","vipProduct":false,"old":false},{"recommended":false,"productId":890,"productName":"乐享人生-安联个人保障计划(青年版)1-2类","planId":884,"planName":"计划一","companyId":69,"companyName":"安联财险","companyShareUrl":"http://files.hzins.com/files/a/a2/a2f/a2fd/a2fd4f931a1a4653942d96639490999f.png","sellCount":508,"defaultPrice":41000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"18-35周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"意外身故及伤残\",\"value\":\"10万元\"},{\"item\":\"意外医疗\",\"value\":\"5000元\"},{\"item\":\"重大疾病保障\",\"value\":\"10万元\"},{\"item\":\"每日住院津贴\",\"value\":\"100元/天\"},{\"item\":\"重症监护每日住院津贴\",\"value\":\"200元/天\"}]","productFeatures":"[\"涵盖40种重疾\",\"专为青年设计\",\"特含电话医生服务\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-890-884.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-890-884.html","vipProduct":false,"old":false},{"recommended":false,"productId":890,"productName":"乐享人生-安联个人保障计划(青年版)1-2类","planId":885,"planName":"计划二","companyId":69,"companyName":"安联财险","companyShareUrl":"http://files.hzins.com/files/a/a2/a2f/a2fd/a2fd4f931a1a4653942d96639490999f.png","sellCount":388,"defaultPrice":98000,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"18-35周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"意外身故及伤残\",\"value\":\"40万元\"},{\"item\":\"意外医疗\",\"value\":\"1万元\"},{\"item\":\"重大疾病保障\",\"value\":\"20万元\"},{\"item\":\"每日住院津贴\",\"value\":\"100元/天\"},{\"item\":\"重症监护每日住院津贴\",\"value\":\"200元/天\"}]","productFeatures":"[\"涵盖40种重疾\",\"专为青年设计\",\"特含电话医生服务\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-890-885.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-890-885.html","vipProduct":false,"old":false},{"recommended":false,"productId":706,"productName":"慧择老年关爱(含重疾)","planId":659,"planName":"计划三加强版（仅限续保）","companyId":57,"companyName":"史带财险","companyShareUrl":"http://files.hzins.com/files/9/9f/9fa/9fa2/9fa29ed14da34f7fbf4c126defefd2da.png","sellCount":7,"defaultPrice":219800,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"71-75周岁\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"个人重大疾病保险\",\"value\":\"5万元\"},{\"item\":\"个人意外伤害保险\",\"value\":\"20万元\"},{\"item\":\"救护车服务津贴\",\"value\":\"500元\"},{\"item\":\"意外医疗\",\"value\":\"2万元\"},{\"item\":\"意外每日住院津贴\",\"value\":\"100元/天\"}]","productFeatures":"[\"续保专用无等待期\",\"重疾/意外双重保障\",\"意外医疗100%赔付\"]","buyQuota":"1","serviceFee":22,"serviceFeeDetail":"推广费22%","basicFeeRate":2200,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-706-659.html","addFeeRate":0,"renewalFeeRate":0,"productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-706-659.html","vipProduct":false,"old":false},{"recommended":false,"productId":100965,"productName":"疾病综合保障计划","planId":102174,"planName":"少儿版","companyId":1075,"companyName":"泰康在线","companyShareUrl":"http://files.huizecdn.com/file1/M00/3B/B9/wKgls1hRBMaAahZ9AAATMFf2WY8530.png","sellCount":4,"defaultPrice":14400,"productProperties":"[{\"item\":\"承保年龄\",\"value\":\"0-17周岁可选\"},{\"item\":\"保障期限\",\"value\":\"1年\"}]","insuranceContents":"[{\"item\":\"重大疾病保险金\",\"value\":\"10万元\"},{\"item\":\"轻症疾病保险金\",\"value\":\"5万元\"},{\"item\":\"少儿白血病保险金\",\"value\":\"10万元\"}]","productFeatures":"[\"70种重疾+10种轻症\",\"少儿白血病叠加给付\",\"性价比高，人性化理赔\"]","serviceFee":11,"serviceFeeDetail":"推广费11%","basicFeeRate":1100,"promoteFeeRate":0,"urlForH5":"https://m.jumi18.com/cps/pad/ay822648/product/detail-100965-102174.html","addFeeRate":0,"renewalFeeRate":0,"productTag":"闪赔","productTagRGB":"4B73EB","productUrl":"https://m.jumi18.com/m/common/to-return-url?returnUrl=https://m.jumi18.com/cps/ay822648/product/detail-100965-102174.html","vipProduct":false,"old":false}],"total":12,"filterType":[{"id":86,"name":"年　　龄","filterItems":[{"id":220,"name":"0－3周岁","filterTypeId":86},{"id":221,"name":"4－16周岁","filterTypeId":86},{"id":222,"name":"17－45周岁","filterTypeId":86},{"id":223,"name":"45周岁以上","filterTypeId":86}]},{"id":83,"name":"重疾种类","filterItems":[{"id":210,"name":"25－35种重疾","filterTypeId":83},{"id":211,"name":"40种及以上重疾","filterTypeId":83}]},{"id":84,"name":"返还金额","filterItems":[{"id":212,"name":"消费型","filterTypeId":84}]},{"id":85,"name":"等待期","filterItems":[{"id":217,"name":"90天","filterTypeId":85},{"id":284,"name":"30天","filterTypeId":85}]}],"companyList":[{"id":56,"companyName":"华泰财险"},{"id":57,"companyName":"史带财险"},{"id":69,"companyName":"安联财险"},{"id":1075,"companyName":"泰康在线"},{"id":1077,"companyName":"易安保险"}],"catetoryList":[{"id":54,"name":"全部"},{"id":55,"name":"一年期重疾","productCount":12},{"id":56,"name":"定期重疾"},{"id":57,"name":"终身重疾"},{"id":58,"name":"防癌重疾"}],"replaceStatus":false},"IsSucc":true,"IsError":false}
         * 
         */

        public static CookieContainer GetCookie()
        {
            var cookie = "jumiRequestToken=02948a4e-e173-4cdf-ae3f-719b94c7e308; wap/passport=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP*BeWA2B2S*RPMVS5kFcFNBjz-7BPXmI9OJv3EFCIDVZYMzrdwdp7X0V9g!!; userId=xviEl6megII%253D; env=production; wap/passport=SVxkmiAcCWzjaZnNtJU1rvyIJu4XP*BeWA2B2S*RPMVS5kFcFNBjz-7BPXmI9OJv3EFCIDVZYMzrdwdp7X0V9g!!; NODE.sessionId=s%3Ap9DsjA7LEyaU9lVG2IZVMWfv5VOiLXbB.b60Vgp%2BofYK%2BaOzwLLjPfN1rVB3AdFfwg0jZGjqqvPw";
            var url = "https://m.jumi18.com/";
            string[] arrCookie = cookie.Split(';');

            CookieContainer cookie_container = new CookieContainer();    //加载Cookie
            //cookie_container.SetCookies(new Uri(url), cookie);
            foreach (string sCookie in arrCookie)
            {
                if (sCookie.IndexOf("expires") > 0)
                    continue;
                cookie_container.SetCookies(new Uri(url), sCookie);
            }
            return cookie_container;
        }
        public static string SetCookie(CookieContainer cookie, string url)
        {
            return cookie.GetCookieHeader(new Uri(url));
        }
        public static string PostLogin(string postData, string requestUrlString, ref CookieContainer cookie)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            //向服务端请求
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrlString);
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36";
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.CookieContainer = new CookieContainer();
            myRequest.AllowAutoRedirect = true;

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            //将请求的结果发送给客户端(界面、应用)
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            cookie.Add(myResponse.Cookies);
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }
        public static string PostRequest(string postData, string requestUrlString, CookieContainer cookie)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(requestUrlString);
            myRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.96 Safari/537.36";
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            myRequest.CookieContainer = cookie;
            myRequest.AllowAutoRedirect = true;

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}

