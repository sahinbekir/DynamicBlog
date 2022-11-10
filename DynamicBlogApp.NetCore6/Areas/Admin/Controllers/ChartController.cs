using DocumentFormat.OpenXml.Drawing.Diagrams;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            return View();
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
