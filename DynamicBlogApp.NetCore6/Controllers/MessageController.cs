using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DynamicBlogApp.NetCore6.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager m2m = new Message2Manager(new EfMessage2Repository());

        public IActionResult InBox()
        {

            int id = 2;
            var values = m2m.GetInboxMessagesListByWriter(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var messagedetail = m2m.GetById(id);
            return View(messagedetail);
        }
    }
}
