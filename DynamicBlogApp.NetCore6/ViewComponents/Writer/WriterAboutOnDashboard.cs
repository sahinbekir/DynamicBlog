using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;
        public WriterAboutOnDashboard( UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = username;
            Context c = new Context();
            var writerid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            //var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();
            
            var values = um.GetWriterById(writerid);
            return View(values);
        }
    }
}
