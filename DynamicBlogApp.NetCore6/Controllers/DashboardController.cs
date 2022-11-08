using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var useremail = User.Identity.Name;
            Context c = new Context();
            var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2=c.Blogs.Where(x=>x.WriterID==writerid).Count().ToString();
            ViewBag.v3 = c.Categories.Count().ToString();
            return View();
        }
    }
}
