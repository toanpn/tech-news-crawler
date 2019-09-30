using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NewsApplications.Controllers
{
    public class GetNewsController : Controller
    {
        // GET: GetNews
        public ActionResult Index()
        {
            HtmlWeb htmlWeb = new HtmlWeb()
             {
                 AutoDetectEncoding = false,
                 OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
             };

            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("https://viblo.asia/newest");

            var threadItems = document.DocumentNode.QuerySelectorAll("div.post-feed-item").ToList();
            var items = new List<object>();

            foreach (var item in threadItems)
            {
                var a = "https://viblo.asia" + item.Attributes["href"].Value.ToString();
                var text = item.InnerText;
                //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;

                items.Add(new { a, text });
            }




            //var threadItems = document.DocumentNode.QuerySelectorAll("h3 > a").ToList();
            //var items = new List<object>();

            //foreach (var item in threadItems)
            //{
            //    var a = "https://viblo.asia" + item.Attributes["href"].Value.ToString();
            //    var text = item.InnerText;
            //    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;

            //    items.Add(new { a, text });
            //}
            return View();
        }
    }
}