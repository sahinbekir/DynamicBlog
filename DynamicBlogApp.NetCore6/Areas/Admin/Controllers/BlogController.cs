using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        //UserManager _writerManager = new WriterManager(new EfWriterRepository());

        public IActionResult ExportStaticExcelBlogList()
        {
            using (var worksbook = new XLWorkbook())
            {
                var worksheet = worksbook.Worksheets.Add("BlogListFormat");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";
                worksheet.Cell(1, 3).Value = "Writer Id";
                worksheet.Cell(1, 4).Value = "Writer Name";


                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.WriterId;
                    worksheet.Cell(BlogRowCount, 4).Value = item.WriterName;
                    BlogRowCount++;
                }
                using (var stream=new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "Blog-List_Format.xlsx");
                }
            }
            

        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
                {
                    new BlogModel{BlogId=1,BlogName="Blog1",WriterId=1,WriterName="Writer1"},
                    new BlogModel{BlogId=2,BlogName="Blog2",WriterId=2,WriterName="Writer2"},
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
                var worksheet = worksbook.Worksheets.Add("BlogListWithWriter");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Name";
                worksheet.Cell(1, 3).Value = "Writer Id";
                worksheet.Cell(1, 4).Value = "Writer Name";


                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    worksheet.Cell(BlogRowCount, 3).Value = item.WriterId;
                    worksheet.Cell(BlogRowCount, 4).Value = item.WriterName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml", "Blog-List_Title-Writer.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> blogListT = new List<BlogModel>();
            //var wn = _writerManager.GetListAll();
            using(var c = new Context())
            {
                blogListT = c.Blogs.Select(x => new BlogModel
                {
                    BlogId = x.BlogID,
                    BlogName = x.BlogTitle,
                    WriterId = x.WriterID,
                    WriterName = c.Users.Where(a => a.Id == x.WriterID).Select(w => w.NameSurname).FirstOrDefault()

                }).ToList();
            }
            return blogListT;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
        public IActionResult AllBlogList()
        {
            var values = _blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }

}
