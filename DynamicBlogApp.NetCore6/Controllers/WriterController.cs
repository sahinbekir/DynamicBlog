using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogApp.NetCore6.Controllers
{
	public class WriterController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
