using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            var values = nm.GetListAll();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNotification(Notification p)
        {
            //var username = User.Identity.Name;
            //var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            p.NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            p.NotificationStatus = true;
            nm.TAdd(p);
            return RedirectToAction("Index", "Notification");
        }
        public IActionResult DeleteNotification(int id)
        {
            var notivalue = nm.GetById(id);
            nm.TDelete(notivalue);
            return RedirectToAction("Index", "Notification");
        }
    }
}
