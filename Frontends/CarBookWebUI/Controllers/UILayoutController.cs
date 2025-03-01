using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
