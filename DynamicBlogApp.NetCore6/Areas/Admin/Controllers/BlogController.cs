using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Spreadsheet;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var worksbook = new XLWorkbook())
            {
                var worksheet = worksbook.Worksheets.Add("BlogList");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";


                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Name;
                    BlogRowCount++;
                }
                using (var stream=new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "Calisma1.xlsx");
                }
            }
            

        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
                {
                    new BlogModel{ID=1,Name="Blog1"},
                    new BlogModel{ID=2,Name="Blog2"},
                    new BlogModel{ID=3,Name="Blog3"},
                };
            return blogList;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var worksbook = new XLWorkbook())
            {
                var worksheet = worksbook.Worksheets.Add("BlogTitleList");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";


                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.Name;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "BlogTitles.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> blogListT = new List<BlogModel>();
            using(var c = new Context())
            {
                blogListT = c.Blogs.Select(x => new BlogModel
                {
                    ID = x.BlogID,
                    Name=x.BlogTitle
                    
                }).ToList();
            }
            return blogListT;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }

}
