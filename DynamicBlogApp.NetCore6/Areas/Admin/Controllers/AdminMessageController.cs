using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public AdminMessageController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult InBox()
        {
            
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxMessagesListByWriter(userid);
            return View(values);
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetSendboxMessagesListByWriter(userid);
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            p.MessageSender = userid;
            p.MessageReceiver = 5;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            p.MessageStatus = true;
            mm.TAdd(p);
            return RedirectToAction("SendBox", "AdminMessage");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("");
        }

    }
}
