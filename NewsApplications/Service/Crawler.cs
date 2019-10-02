using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using NewsApplications.Models;
using NewsApplications.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace NewsApplications.Service
{
    public class Crawler
    {
        private HtmlWeb htmlWeb = new HtmlWeb()
        {
            AutoDetectEncoding = true,
            OverrideEncoding = Encoding.UTF8
        };

        public ListPosts GetNewsVibloOnPage(int page)
        {
            string URLVIBLO = "https://viblo.asia/newest?page=" + page;

            HtmlDocument document = htmlWeb.Load(URLVIBLO);

            var threadItems = document.DocumentNode.QuerySelectorAll("div.post-feed-item").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                HtmlNode i = item.QuerySelectorAll("div.post-feed-item__info > div > h3 > a").FirstOrDefault();
                post.link = "https://viblo.asia" + i.Attributes["href"].Value.ToString();
                post.text = i.InnerText;
                //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                var b = item.QuerySelectorAll("span.stats-item").FirstOrDefault();
                int _viewcount = 0;
                int.TryParse(b.InnerText.Trim(), out _viewcount);
                post.viewcount = _viewcount;
                post.source = "Vilbo";
                items.listPosts.Add(post);
            }
            return items;
        }

        public ListPosts GetSpiderumPostOnPage(int page)
        {
            string URLSPI = "https://spiderum.com/s/all/hot?page=" + page;

            HtmlDocument document = htmlWeb.Load(URLSPI);

            var threadItems = document.DocumentNode.QuerySelectorAll("li.feed-post").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                try
                {
                    HtmlNode i = item.QuerySelectorAll("div h3 a").FirstOrDefault();
                    post.link = "https://spiderum.com" + i.Attributes["href"].Value.ToString();
                    post.text = i.InnerText;
                    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                    var b = item.QuerySelectorAll("span.vote-count").FirstOrDefault();
                    int _viewcount = 0;
                    int.TryParse(b.InnerText.Trim(), out _viewcount);
                    post.viewcount = _viewcount;
                    post.source = "Spiderum";
                    items.listPosts.Add(post);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        public ListPosts GetVozF33PostOnPage(int page)
        {
            string URLSPI = "https://forums.voz.vn/forumdisplay.php?f=33&order=desc&page=" + page;

            HtmlDocument document = htmlWeb.Load(URLSPI);

            var threadItems = document.DocumentNode.QuerySelectorAll("tbody tr").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                try
                {
                    HtmlNode i = item.QuerySelectorAll("td:nth-child(2) div:nth-child(1) a:nth-child(1)").FirstOrDefault();
                    post.link = "https://forums.voz.vn/" + i.Attributes["href"].Value.ToString();
                    post.text = i.InnerText;
                    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                    //var b = item.QuerySelectorAll("span.vote-count").FirstOrDefault();
                    //int _viewcount = 0;
                    //int.TryParse(b.InnerText.Trim(), out _viewcount);
                    //post.viewcount = _viewcount;
                    post.source = "F33";
                    items.listPosts.Add(post);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        public ListPosts GetTamLyHocPostOnPage(int page)
        {
            string URLSPI = "http://tamlyhoctoipham.com/bai-viet?page=" + page;

            HtmlDocument document = htmlWeb.Load(URLSPI);

            var threadItems = document.DocumentNode.QuerySelectorAll("div.item").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                try
                {
                    HtmlNode i = item.QuerySelectorAll("div h2 a").FirstOrDefault();
                    post.link = i.Attributes["href"].Value.ToString();
                    post.text = i.InnerText;
                    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                    var b = item.QuerySelectorAll("span.vote-count").FirstOrDefault();
                    //int _viewcount = 0;
                    //int.TryParse(b.InnerText.Trim(), out _viewcount);
                    //post.viewcount = _viewcount;
                    post.source = "TamLyHocToiPham";
                    items.listPosts.Add(post);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        public ListPosts GetToiDiCodeDaoPostOnPage(int page)
        {
            string URLSPI = "https://toidicodedao.com/page/" + page;
            htmlWeb.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            HtmlDocument document = htmlWeb.Load(URLSPI);

            var threadItems = document.DocumentNode.QuerySelectorAll("article.post").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                try
                {
                    HtmlNode i = item.QuerySelectorAll("header h1 a").FirstOrDefault();
                    post.link = i.Attributes["href"].Value.ToString();
                    post.text = i.InnerText;
                    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                    //var b = item.QuerySelectorAll("span.vote-count").FirstOrDefault();
                    //int _viewcount = 0;
                    //int.TryParse(b.InnerText.Trim(), out _viewcount);
                    //post.viewcount = _viewcount;
                    post.source = "Tôi Đi Code Dạo";
                    items.listPosts.Add(post);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        public ListPosts GetCodeaHolicGuyPostOnPage(int page)
        {
            string URLSPI = "https://codeaholicguy.com/page/" + page;
            htmlWeb.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            HtmlDocument document = htmlWeb.Load(URLSPI);

            var threadItems = document.DocumentNode.QuerySelectorAll("article.post").ToList();
            ListPosts items = new ListPosts();

            foreach (var item in threadItems)
            {
                Post post = new Post();

                try
                {
                    HtmlNode i = item.QuerySelectorAll("header h1 a").FirstOrDefault();
                    post.link = i.Attributes["href"].Value.ToString();
                    post.text = i.InnerText;
                    //var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;
                    //var b = item.QuerySelectorAll("span.vote-count").FirstOrDefault();
                    //int _viewcount = 0;
                    //int.TryParse(b.InnerText.Trim(), out _viewcount);
                    //post.viewcount = _viewcount;
                    post.source = "CodeaHolicGuy";
                    items.listPosts.Add(post);
                }
                catch (Exception)
                {
                }
            }
            return items;
        }

        //public ListPosts GetKipalogPostOnPage(int page)
        //{
        //    string URLSPI = "https://kipalog.com/posts/pagination?filter=new&page=" + page;
        //    using (var client = new WebClient())
        //    {
        //        var json = client.DownloadString(URLSPI);
        //        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //        // TODO: do something with the model
        //    }
        //    return null;
        //}
    }
}