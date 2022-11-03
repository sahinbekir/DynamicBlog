﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager nlm = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubsMail()
		{
			return PartialView();
		}
		[HttpPost]
        public PartialViewResult SubsMail(NewsLetter p)
        {
			p.MailStatus = true;
			nlm.AddNewsLetter(p);
            return PartialView();
        }
    }
}