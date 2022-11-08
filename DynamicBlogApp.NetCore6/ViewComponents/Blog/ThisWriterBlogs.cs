using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Blog
{
    public class ThisWriterBlogs : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            // O blogun yazarının blogları lazım.
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }
    }
}
