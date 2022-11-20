using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticFour : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var adminid=context.Users.Where(x=> x.UserName == username).Select(y=>y.Id).FirstOrDefault();
            ViewBag.v1 = context.Users.Where(x=>x.Id== adminid).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.v2 = context.Users.Where(x => x.Id == adminid).Select(y => y.UserName).FirstOrDefault();
            ViewBag.v3 = context.Users.Where(x => x.Id == adminid).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v4 = context.Users.Where(x => x.Id == adminid).Select(y => y.NameSurname).FirstOrDefault();
            ViewBag.v5 = context.Users.Where(x => x.Id == adminid).Select(y => y.Email).FirstOrDefault();
            ViewBag.v6 = context.Users.Where(x => x.Id == adminid).Select(y => y.UserName).FirstOrDefault();
            ViewBag.v7 = context.Users.Where(x => x.Id == adminid).Select(y => y.PhoneNumber).FirstOrDefault();

            return View();
        }
    }
}
