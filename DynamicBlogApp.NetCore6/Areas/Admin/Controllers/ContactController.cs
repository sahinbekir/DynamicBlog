using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        public IActionResult Index()
        {
            var values = cm.GetListAll();
            return View(values);
        }
        /*
        public IActionResult DeleteContact(int id)
        {
            var contactvalue = cm.GetById(id);
            cm.TDelete(contactvalue)
            return RedirectToAction("/Admin/Contact/Index/");
        }*/
    }
}
