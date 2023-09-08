using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class VisiterMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
