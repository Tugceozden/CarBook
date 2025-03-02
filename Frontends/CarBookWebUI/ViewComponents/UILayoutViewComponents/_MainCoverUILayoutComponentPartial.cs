using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
