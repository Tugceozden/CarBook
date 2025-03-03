using Microsoft.AspNetCore.Mvc;

namespace CarBookWebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
