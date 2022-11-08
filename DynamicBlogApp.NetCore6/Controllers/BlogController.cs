using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using DataAccessLayer.Concrete;

namespace DynamicBlogApp.NetCore6.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.i=id;
            //ViewBag.wi = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var useremail = User.Identity.Name;
            Context c = new Context();
            var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();
            var values=bm.GetListCategoryByWriterBm(writerid);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoriesRepository());
            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                var useremail = User.Identity.Name;
                Context c = new Context();
                var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();

                p.WriterID = writerid;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.GetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoriesRepository());
            var blogvalue = bm.GetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var useremail = User.Identity.Name;
            Context c = new Context();
            var writerid = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();

            p.WriterID=writerid;
            p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }


    }
}
