using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());

        public IViewComponentResult Invoke()
        {
            string p;
            p = "bs_sb@gmail.com";
            //var values = mm.GetListAll();
            var values = mm.GetInboxMessagesListByWriter(p);
            return View(values);
        }
    }
}
