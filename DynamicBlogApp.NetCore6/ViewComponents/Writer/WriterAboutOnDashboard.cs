using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var useremail = User.Identity.Name;
            Context c = new Context();
            var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();

            var values = wm.GetWriterById(writerid);
            return View(values);
        }
    }
}
