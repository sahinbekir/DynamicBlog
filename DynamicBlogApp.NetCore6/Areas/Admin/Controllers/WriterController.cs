﻿using DynamicBlogApp.NetCore6.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DynamicBlogApp.NetCore6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x=>x.Id==writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass()
            {
                Id=1,
                Name="Bekir"
            },
            new WriterClass()
            {
                Id =2,
                Name = "Şahin"
            }
        };
    }
}
