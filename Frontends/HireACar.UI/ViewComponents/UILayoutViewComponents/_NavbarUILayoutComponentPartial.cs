using Microsoft.AspNetCore.Mvc;

namespace HireACar.UI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
