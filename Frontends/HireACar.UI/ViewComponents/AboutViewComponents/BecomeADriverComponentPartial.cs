using Microsoft.AspNetCore.Mvc;

namespace HireACar.UI.ViewComponents.AboutViewComponents
{
	public class BecomeADriverComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
