using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.ViewComponents.Statistic
{
    public class StatisticFour : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x=>x.AdminID==1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDesc).FirstOrDefault();
            ViewBag.v3 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v4 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.LongDesc).FirstOrDefault();
            ViewBag.v5 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.Email).FirstOrDefault();
            ViewBag.v6 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.Address).FirstOrDefault();
            ViewBag.v7 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.PhoneNum).FirstOrDefault();

            return View();
        }
    }
}
