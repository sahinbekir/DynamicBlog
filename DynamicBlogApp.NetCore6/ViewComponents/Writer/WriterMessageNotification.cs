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
            var useremail = User.Identity.Name;
            Context c = new Context();
            var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();

            var values = mm.GetInboxMessagesListByWriter(writerid);
            return View(values);
        }
    }
}
