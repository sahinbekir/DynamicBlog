using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DynamicBlogApp.NetCore6.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticF:ViewComponent
    {
        //BlogManager bm = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1= context.Blogs?.Count();
            ViewBag.v2=context.Contacts?.Count();
            ViewBag.v3 = context.Comments?.Count();

            //https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=2b55960fb3cc42e0119e195986eee959
            //string myapikey = "2b55960fb3cc42e0119e195986eee959";
            //string connection = "https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=" + myapikey;
            string api = "14ad2aba611dbef9c504b82a127794c5";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Hatay&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);            
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            
            return View();
        }
    }
}
