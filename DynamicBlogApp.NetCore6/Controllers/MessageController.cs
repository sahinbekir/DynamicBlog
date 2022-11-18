using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DynamicBlogApp.NetCore6.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager m2m = new Message2Manager(new EfMessage2Repository());
        public IActionResult SendBox()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = m2m.GetSendboxMessagesListByWriter(userid);
            return View(values);
        }
        public IActionResult InBox()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x=>x.UserName==username).Select(y=>y.Id).FirstOrDefault();
            var values = m2m.GetInboxMessagesListByWriter(userid);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messagedetail = m2m.GetById(id);
            return View(messagedetail);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            p.MessageSender = userid;
            p.MessageStatus = true;
            p.MessageReceiver = 5;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            m2m.TAdd(p);

            return RedirectToAction("SendBox");
        }
    }
}
