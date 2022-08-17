using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.ViewComponents.Category
{
    public class CategoryList : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoriesRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetListAll();
            return View(values);
        }
    }
}
