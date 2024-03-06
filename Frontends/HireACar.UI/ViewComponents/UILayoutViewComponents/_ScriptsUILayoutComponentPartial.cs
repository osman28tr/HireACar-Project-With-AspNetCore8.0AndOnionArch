using Microsoft.AspNetCore.Mvc;

namespace HireACar.UI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
