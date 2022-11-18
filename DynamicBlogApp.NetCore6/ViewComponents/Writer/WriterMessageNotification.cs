using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            Context c = new Context();
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();

            var values = mm.GetInbox3MessagesListByWriter(userid);
            return View(values);
        }
    }
}
