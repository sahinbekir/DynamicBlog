using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
    public class AdminController : Controller
    {
        
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
