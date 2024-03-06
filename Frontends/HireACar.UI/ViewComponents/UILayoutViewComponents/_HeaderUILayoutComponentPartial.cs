using Microsoft.AspNetCore.Mvc;

namespace HireACar.UI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
