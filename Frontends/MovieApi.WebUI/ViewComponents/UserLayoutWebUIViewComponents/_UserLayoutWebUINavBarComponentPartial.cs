using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUINavBarComponentPartial : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
