using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
	{
		ContactManager cm = new ContactManager(new EfContactRepository());
        AboutManager am = new AboutManager(new EfAboutRepository());
        [HttpGet]
		public IActionResult Index()
		{
			var values = am.GetListAll();
			return View(values);
		}
		[HttpPost]
		public IActionResult Index(Contact p)
		{
			p.ContactDate= DateTime.Parse(DateTime.Now.ToShortDateString());
			p.ContactStatus = true;
			cm.ContactAdd(p);
			return RedirectToAction("Index","Blog");
		}
	}
}
