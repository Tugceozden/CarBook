using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invooke()
        {
            return View();  
        }
    }
}
