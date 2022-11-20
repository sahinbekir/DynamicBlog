using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChartController : Controller
    {
        CategoryManager categoryManager= new CategoryManager(new EfCategoriesRepository());
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterChartIndex()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            var cvalues = categoryManager.GetListAll();
            var bvalues = blogManager.GetListAll();
            List<CategoryChartClass> list = new List<CategoryChartClass>();

            foreach (var value in cvalues)
            {
                var count = 0;

                foreach (var item in bvalues)
                {
                    if (value.CategoryID == item.CategoryID)
                    {
                        count++;
                    }
                }
                list.Add(new CategoryChartClass
                {
                    categoryname = value.CategoryName,
                    categorycount = count,
                });
            }
            return Json(new { chart = list });
        }
        public IActionResult WriterChart()
        {
            var uvalues=userManager.GetListAll();
            var bvalues = blogManager.GetListAll();
            List<WriterChartClass> wlist = new List<WriterChartClass>();

            foreach (var value in uvalues)
            {
                var count=0;

                foreach (var item in bvalues)
                {
                    if (value.Id==item.WriterID)
                    {
                        count++;
                    }
                }
                wlist.Add(new WriterChartClass
                {
                    writername = value.NameSurname,
                    writercount = count,
                });
            }
            return Json(new { wchart = wlist });
        }
        public IActionResult CategoryChartTest()
        {
            List<CategoryChartClass> list = new List<CategoryChartClass>();
            list.Add(new CategoryChartClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryChartClass
            {
                categoryname = "Araba",
                categorycount = 9
            });
            list.Add(new CategoryChartClass
            {
                categoryname = "Telefon",
                categorycount = 1
            });
            return Json(new {charttest=list});
        }
    }
}
