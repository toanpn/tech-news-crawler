using NewsApplications.Service;
using NewsApplications.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsApplications.Controllers
{
    public class HomeController : Controller
    {
        Crawler crawler = new Crawler();

        public ActionResult Index()
        {
            ListPosts listPosts = crawler.GetNewsVibloOnPage(1);
            listPosts.listPosts.AddRange(crawler.GetToiDiCodeDaoPostOnPage(1).listPosts);
            //listPosts.listPosts.AddRange(crawler.GetKipalogPostOnPage(1).listPosts);
            listPosts.listPosts.AddRange(crawler.GetCodeaHolicGuyPostOnPage(1).listPosts);
            listPosts.listPosts.AddRange(crawler.GetSpiderumPostOnPage(1).listPosts);
            listPosts.listPosts.AddRange(crawler.GetTamLyHocPostOnPage(1).listPosts);
            listPosts.listPosts.AddRange(crawler.GetVozF33PostOnPage(1).listPosts);
            return View(listPosts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}