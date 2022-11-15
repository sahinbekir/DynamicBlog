using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
	{
		NewsLetterManager nlm = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubsMail()
		{
			return PartialView();
		}
		[HttpPost]
        public IActionResult SubsMail(NewsLetter p)
        {
			p.MailStatus = true;
			nlm.AddNewsLetter(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
